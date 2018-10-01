namespace NLayer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mgrtn1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.String(),
                        TimeRealization = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOffers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerOffers", new[] { "CustomerID" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOffers");
        }
    }
}
