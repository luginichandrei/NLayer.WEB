namespace NLayer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgrtn2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CurrentCategory = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        CurrentCompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CurrentCompanyId, cascadeDelete: true)
                .Index(t => t.CurrentCompanyId);
            
            AlterColumn("dbo.CustomerOffers", "TimeRealization", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Executors", "CurrentCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Offers", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Executors", new[] { "CurrentCompanyId" });
            DropIndex("dbo.Offers", new[] { "Category_Id" });
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CustomerOffers", "TimeRealization", c => c.String(nullable: false));
            DropTable("dbo.Executors");
            DropTable("dbo.Companies");
            DropTable("dbo.Offers");
            DropTable("dbo.Categories");
        }
    }
}
