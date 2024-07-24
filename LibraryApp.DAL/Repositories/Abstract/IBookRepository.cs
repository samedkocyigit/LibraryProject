using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Abstract
{
    public interface IBookRepository:GenericRepository<Book>
    {
        IEnumerable<Book> GetBooksByFloor(int floorId);
        IEnumerable<Book> GetBooksByCategory(int categoryId);
        Book GetBookByTitle(string title);
    }
}
