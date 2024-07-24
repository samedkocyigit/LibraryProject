namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMember : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Members", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("public.Members", "Role", c => c.Int(nullable: false));
        }
    }
}
