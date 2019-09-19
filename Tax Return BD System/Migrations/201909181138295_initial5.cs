namespace Tax_Return_BD_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubMenuItems", "MenuId", c => c.Int(nullable: false));
            DropColumn("dbo.SubMenuItems", "MenuName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubMenuItems", "MenuName", c => c.String());
            DropColumn("dbo.SubMenuItems", "MenuId");
        }
    }
}
