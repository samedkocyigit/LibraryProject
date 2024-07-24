namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthor : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Authors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("public.Authors", "LastName", c => c.String());
        }
    }
}
