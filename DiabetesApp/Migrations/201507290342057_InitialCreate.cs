namespace DiabetesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InputModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        user = c.String(),
                        inputDate = c.DateTime(nullable: false),
                        bloodSugarAmount = c.Int(),
                        weightAmount = c.Int(),
                        carbAmount = c.Int(),
                        a1cAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InputModels");
        }
    }
}
