namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileDetails", "UserDocument_DocumentId", "dbo.UserDocuments");
            DropIndex("dbo.FileDetails", new[] { "UserDocument_DocumentId" });
            RenameColumn(table: "dbo.FileDetails", name: "UserDocument_DocumentId", newName: "DocumentId");
            AlterColumn("dbo.FileDetails", "DocumentId", c => c.Int(nullable: false));
            CreateIndex("dbo.FileDetails", "DocumentId");
            AddForeignKey("dbo.FileDetails", "DocumentId", "dbo.UserDocuments", "DocumentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDetails", "DocumentId", "dbo.UserDocuments");
            DropIndex("dbo.FileDetails", new[] { "DocumentId" });
            AlterColumn("dbo.FileDetails", "DocumentId", c => c.Int());
            RenameColumn(table: "dbo.FileDetails", name: "DocumentId", newName: "UserDocument_DocumentId");
            CreateIndex("dbo.FileDetails", "UserDocument_DocumentId");
            AddForeignKey("dbo.FileDetails", "UserDocument_DocumentId", "dbo.UserDocuments", "DocumentId");
        }
    }
}
