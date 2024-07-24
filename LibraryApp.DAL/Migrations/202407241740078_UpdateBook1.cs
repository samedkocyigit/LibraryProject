namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBook1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Books", "IsBorrowed", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("public.Books", "IsBorrowed");
        }
    }
}
