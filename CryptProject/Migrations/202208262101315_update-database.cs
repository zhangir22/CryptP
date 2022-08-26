namespace CryptProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptValues", "name", c => c.String());
            AddColumn("dbo.CryptValues", "symbol", c => c.String());
            AddColumn("dbo.CryptValues", "logo", c => c.String());
            AddColumn("dbo.CryptValues", "price", c => c.String());
            AddColumn("dbo.CryptValues", "volume_change_24h", c => c.String());
            AddColumn("dbo.CryptValues", "market_cap", c => c.String());
            AddColumn("dbo.CryptValues", "last_update", c => c.DateTime());
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.CryptValues", "name");
        }
    }
}
