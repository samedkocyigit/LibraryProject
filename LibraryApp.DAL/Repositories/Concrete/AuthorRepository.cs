using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class AuthorRepository:GenericRepository<Author>,IAuthorRepository
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context):base(context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            var author = _context.Authors.Include(a=>a.Books).FirstOrDefault(a=> a.AuthorId==authorId);
            return author?.Books ?? new List<Book>();
        }
        public Author GetAuthorByName(string name)
        {
            var author = _context.Authors
                                        .Include(a => a.Books)
                                        .FirstOrDefault(a => a.Name == name);
            return author;
        }
    }
}
