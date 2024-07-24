namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookandAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Authors", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.Authors", "Name", c => c.String());
        }
    }
}
