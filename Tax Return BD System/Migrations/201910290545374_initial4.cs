namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserDocuments");
            AddColumn("dbo.UserDocuments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserDocuments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserDocuments");
            DropColumn("dbo.UserDocuments", "Id");
            AddPrimaryKey("dbo.UserDocuments", "DocumentId");
        }
    }
}
