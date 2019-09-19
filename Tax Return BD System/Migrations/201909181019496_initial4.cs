namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.SubMenuItems",
                c => new
                    {
                        SubMenuId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                    })
                .PrimaryKey(t => t.SubMenuId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubMenuItems");
            DropTable("dbo.MenuItems");
        }
    }
}
