namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Members", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Members", "Role");
        }
    }
}
