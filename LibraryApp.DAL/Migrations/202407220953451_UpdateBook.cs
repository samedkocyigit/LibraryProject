namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Books", "Author_AuthorId", "public.Authors");
            DropIndex("public.Books", new[] { "Author_AuthorId" });
            RenameColumn(table: "public.Books", name: "Author_AuthorId", newName: "AuthorId");
            AlterColumn("public.Books", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("public.Books", "AuthorId");
            AddForeignKey("public.Books", "AuthorId", "public.Authors", "AuthorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.Books", "AuthorId", "public.Authors");
            DropIndex("public.Books", new[] { "AuthorId" });
            AlterColumn("public.Books", "AuthorId", c => c.Int());
            RenameColumn(table: "public.Books", name: "AuthorId", newName: "Author_AuthorId");
            CreateIndex("public.Books", "Author_AuthorId");
            AddForeignKey("public.Books", "Author_AuthorId", "public.Authors", "AuthorId");
        }
    }
}
