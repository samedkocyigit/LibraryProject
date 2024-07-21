namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "public.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        MembershipDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("public.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "public.Borrowings",
                c => new
                    {
                        BorrowingId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        BorrowedDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BorrowingId)
                .ForeignKey("public.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("public.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "public.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        PublishedYear = c.Int(nullable: false),
                        ShelfId = c.Int(nullable: false),
                        Author_AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("public.Authors", t => t.Author_AuthorId)
                .ForeignKey("public.Shelves", t => t.ShelfId, cascadeDelete: true)
                .Index(t => t.ShelfId)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "public.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "public.Shelves",
                c => new
                    {
                        ShelfId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShelfId)
                .ForeignKey("public.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "public.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FloorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("public.Floors", t => t.FloorId, cascadeDelete: true)
                .Index(t => t.FloorId);
            
            CreateTable(
                "public.Floors",
                c => new
                    {
                        FloorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FloorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Borrowings", "MemberId", "public.Members");
            DropForeignKey("public.Shelves", "CategoryId", "public.Categories");
            DropForeignKey("public.Categories", "FloorId", "public.Floors");
            DropForeignKey("public.Books", "ShelfId", "public.Shelves");
            DropForeignKey("public.Borrowings", "BookId", "public.Books");
            DropForeignKey("public.Books", "Author_AuthorId", "public.Authors");
            DropForeignKey("public.Members", "AddressId", "public.Addresses");
            DropIndex("public.Categories", new[] { "FloorId" });
            DropIndex("public.Shelves", new[] { "CategoryId" });
            DropIndex("public.Books", new[] { "Author_AuthorId" });
            DropIndex("public.Books", new[] { "ShelfId" });
            DropIndex("public.Borrowings", new[] { "MemberId" });
            DropIndex("public.Borrowings", new[] { "BookId" });
            DropIndex("public.Members", new[] { "AddressId" });
            DropTable("public.Floors");
            DropTable("public.Categories");
            DropTable("public.Shelves");
            DropTable("public.Authors");
            DropTable("public.Books");
            DropTable("public.Borrowings");
            DropTable("public.Members");
            DropTable("public.Addresses");
        }
    }
}
