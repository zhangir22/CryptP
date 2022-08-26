namespace CryptProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Xam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CryptValues",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        symbol = c.String(),
                        logo = c.String(),
                        price = c.Int(nullable: false),
                        volume_change_24h = c.String(),
                        market_cap = c.Int(nullable: false),
                        last_update = c.DateTime()

                })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.CryptValues");
        }
    }
}
