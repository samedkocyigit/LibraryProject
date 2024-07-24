namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Addresses", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Addresses", "DeletedTime", c => c.DateTime());
            AddColumn("public.Addresses", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Addresses", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Members", "Username", c => c.String());
            AddColumn("public.Members", "Password", c => c.String());
            AddColumn("public.Members", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Members", "DeletedTime", c => c.DateTime());
            AddColumn("public.Members", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Members", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Borrowings", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Borrowings", "DeletedTime", c => c.DateTime());
            AddColumn("public.Borrowings", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Borrowings", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Books", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Books", "DeletedTime", c => c.DateTime());
            AddColumn("public.Books", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Books", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Authors", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Authors", "DeletedTime", c => c.DateTime());
            AddColumn("public.Authors", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Authors", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Shelves", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Shelves", "DeletedTime", c => c.DateTime());
            AddColumn("public.Shelves", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Shelves", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Categories", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Categories", "DeletedTime", c => c.DateTime());
            AddColumn("public.Categories", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Categories", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("public.Floors", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("public.Floors", "DeletedTime", c => c.DateTime());
            AddColumn("public.Floors", "ModifiedTime", c => c.DateTime());
            AddColumn("public.Floors", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Floors", "IsActive");
            DropColumn("public.Floors", "ModifiedTime");
            DropColumn("public.Floors", "DeletedTime");
            DropColumn("public.Floors", "CreatedTime");
            DropColumn("public.Categories", "IsActive");
            DropColumn("public.Categories", "ModifiedTime");
            DropColumn("public.Categories", "DeletedTime");
            DropColumn("public.Categories", "CreatedTime");
            DropColumn("public.Shelves", "IsActive");
            DropColumn("public.Shelves", "ModifiedTime");
            DropColumn("public.Shelves", "DeletedTime");
            DropColumn("public.Shelves", "CreatedTime");
            DropColumn("public.Authors", "IsActive");
            DropColumn("public.Authors", "ModifiedTime");
            DropColumn("public.Authors", "DeletedTime");
            DropColumn("public.Authors", "CreatedTime");
            DropColumn("public.Books", "IsActive");
            DropColumn("public.Books", "ModifiedTime");
            DropColumn("public.Books", "DeletedTime");
            DropColumn("public.Books", "CreatedTime");
            DropColumn("public.Borrowings", "IsActive");
            DropColumn("public.Borrowings", "ModifiedTime");
            DropColumn("public.Borrowings", "DeletedTime");
            DropColumn("public.Borrowings", "CreatedTime");
            DropColumn("public.Members", "IsActive");
            DropColumn("public.Members", "ModifiedTime");
            DropColumn("public.Members", "DeletedTime");
            DropColumn("public.Members", "CreatedTime");
            DropColumn("public.Members", "Password");
            DropColumn("public.Members", "Username");
            DropColumn("public.Addresses", "IsActive");
            DropColumn("public.Addresses", "ModifiedTime");
            DropColumn("public.Addresses", "DeletedTime");
            DropColumn("public.Addresses", "CreatedTime");
        }
    }
}
