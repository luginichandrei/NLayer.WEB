namespace NLayer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgrtn3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeRalization = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyOffers");
        }
    }
}
