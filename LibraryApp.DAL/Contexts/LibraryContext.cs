using LibraryApp.Domains.Models;
using System.Data.Entity;

namespace LibraryApp.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
