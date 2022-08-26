using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptProject.Models
{
    public class CryptValue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string logo { get; set; }
        public string price { get; set; }
        public string volume_change_24h { get; set; }
        public string market_cap { get; set; }
        public DateTime? last_update { get; set; }

    }
}