namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationInformations",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.FirstName);
            
            CreateTable(
                "dbo.RoleInformations",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleInformations");
            DropTable("dbo.RegistrationInformations");
        }
    }
}
