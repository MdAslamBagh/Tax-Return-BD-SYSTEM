namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RegistrationInformations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegistrationInformations",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Status = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.FirstName);
            
        }
    }
}
