using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CryptProject.Models.Context;
using Newtonsoft.Json.Linq;
using CryptProject.Models;
namespace CryptProject.Controllers
{
    [Authorize]
    public class CryptController : Controller
    {

        private static string _apiKey = "a9341d23-665d-414a-8b7b-99b1e550245f";
        private static string urlListingsNew = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?";

        private static JObject makeAPICall(string url, string apiKey)
        {
            var URL = new UriBuilder(url);

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", apiKey);
            client.Headers.Add("Accepts", "application/json");
            JObject obj = JObject.Parse(client.DownloadString(URL.ToString()));
            return obj;
        }
        private List<CryptValue> GetDataCrypt()
        {
            List<CryptValue> values = new List<CryptValue>();
            dynamic obj = makeAPICall(urlListingsNew, _apiKey);
            foreach (var item in obj.data)
            {
                values.Add(
                    new CryptValue
                    {
                        id = item.id,
                        name = item.name,
                        logo = $"https://s2.coinmarketcap.com/static/img/coins/64x64/{item.id}.png",
                        symbol = item.symbol,
                        price = item.quote.USD.price,
                        volume_change_24h = item.quote.USD.volume_change_24h,
                        market_cap = item.quote.USD.market_cap,
                        last_update = item.quote.USD.last_update
                    });
            }
            return values;
        }
        private List<CryptValue> crypts;
        public CryptController()
        {
            crypts = GetDataCrypt();
        }
       
        // GET: Crypt
        public ActionResult Index(string value)
        {
            using(ContextData db = new ContextData())
            {
                var lst = db.CryptValues.ToList();
                if (lst.Count != 0)
                {
                    
                    if (value == "name")
                    {
                        return View(lst.OrderBy(n=>n.name).ToList());
                    }

                    if (value == "symbol")
                    {
                        return View(lst.OrderBy(s => s.symbol).ToList());
                    }
                    if (value == "price")
                    {
                        return View(lst.OrderBy(p => p.price).ToList());
                    }
                    if (value == "last_update")
                    {
                        return View(lst.OrderBy(l => l.last_update).ToList());
                    }
                    if (value == "market_cap")
                    {
                        return View(lst.OrderBy(m => m.market_cap).ToList());
                    }
                    if (value == "id")
                    {
                        return View(lst.OrderBy(i => i.id).ToList());
                    }
                    return View(lst);
                }
                else
                {
                    foreach(var item in crypts)
                    {
                        db.CryptValues.Add(item);
                    }
                    db.SaveChanges();
                    return View(db.CryptValues.ToList());
                }
            }
        }
    }
}