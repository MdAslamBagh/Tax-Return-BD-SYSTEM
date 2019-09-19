namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDocuments",
                c => new
                    {
                        DocumentName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DocumentName);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        Phoneno = c.String(),
                        Password = c.String(),
                        Confirm_Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
            DropTable("dbo.UserDocuments");
        }
    }
}
