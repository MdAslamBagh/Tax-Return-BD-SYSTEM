namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxYears",
                c => new
                    {
                        TaxYearId = c.Int(nullable: false, identity: true),
                        Tax_Year = c.String(),
                        Default_Code = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaxYearId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaxYears");
        }
    }
}
