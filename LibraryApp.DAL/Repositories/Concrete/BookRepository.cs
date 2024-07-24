using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context):base(context) 
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooksByFloor(int floorId)
        {
            return _context.Books
                                .Include(b=>b.Shelf)
                                .Include(b=>b.Shelf.Category)
                                .Include(b=>b.Shelf.Category.Floor)
                                .Where(b => b.Shelf.Category.Floor.FloorId == floorId)
                                .ToList();
        }
        public IEnumerable<Book> GetBooksByCategory(int categoryId)
        {
            return _context.Books
                                .Include(b => b.Shelf)
                                .Include(b => b.Shelf.Category)
                                .Include(b => b.Shelf.Category.Floor)
                                .Where(b=>b.Shelf.CategoryId == categoryId)
                                .ToList();
        }
        public Book GetBookByTitle(string title)
        {
            return _context.Books
                                .Include(b => b.Shelf)
                                .Include(b => b.Shelf.Category)
                                .Include(b => b.Shelf.Category.Floor)
                                .FirstOrDefault(b=>b.Title == title);
        }
    }
}
