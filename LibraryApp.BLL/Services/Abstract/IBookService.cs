using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooksByFloor(int floorId);
        IEnumerable<Book> GetBooksByCategory(int categoryId);
        IEnumerable<Book> GetAllBooks();
        Book GetBookByTitle(string title);
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
