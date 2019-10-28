namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDocuments", "Document", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDocuments", "Document");
        }
    }
}
