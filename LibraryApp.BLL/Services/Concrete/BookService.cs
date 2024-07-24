using LibraryApp.BLL.Services.Abstract;
using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }
        public IEnumerable<Book> GetBooksByFloor(int floorId) 
        {
            return _bookRepository.GetBooksByFloor(floorId);
        }
        public IEnumerable<Book> GetBooksByCategory(int categoryId) 
        {
            return _bookRepository.GetBooksByCategory(categoryId);
        }
        public Book GetBookByTitle(string title)
        {
            return _bookRepository.GetBookByTitle(title);
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.Insert(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
            }
        }
    }
}
