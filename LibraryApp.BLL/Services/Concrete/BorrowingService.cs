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
    public class BorrowingService:IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowingService( IBorrowingRepository borrowingRepository, IBookRepository bookRepository)
        {
            _borrowingRepository = borrowingRepository;
            _bookRepository = bookRepository;
        }

        public IEnumerable<Borrowing> GetAllBorrowings()
        {
            return _borrowingRepository.GetAll();
        }

        public void BorrowBook(int memberId,int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null || book.IsBorrowed)
            {
                throw new Exception("Book is not available");
            }

            var borrowing = new Borrowing
            {
                MemberId = memberId,
                BookId = bookId,
                BorrowedDate = DateTime.Now
            };

            _borrowingRepository.Insert(borrowing);
            book.IsBorrowed = true;
            _bookRepository.Update(book);
            Console.WriteLine($"Book with ID {bookId} has been borrowed. IsBorrowed: {book.IsBorrowed}");

        }


        public void ReturnBook(int memberId,int bookId)
        {
            var borrowing = _borrowingRepository.GetAll()
                .FirstOrDefault(b=>b.MemberId== memberId && b.BookId==bookId && b.ReturnedDate==null);
            if (borrowing == null)
            {
                throw new Exception("Borrowing record not found.");
            }

            borrowing.ReturnedDate= DateTime.Now;
            _borrowingRepository.Update(borrowing);

            var book = _bookRepository.GetById(bookId);
            book.IsBorrowed = false;
            _bookRepository.Update(book);
        }

        public IEnumerable<Borrowing> GetBorrowingsByMember(int memberId)
        {
            return _borrowingRepository.GetBorrowingsByMember(memberId);
        }

        public IEnumerable<Borrowing> GetBorrowingsByBook(int bookId)
        {
            return _borrowingRepository.GetBorrowingsByBook(bookId);
        }
        public Borrowing GetBorrowingById(int id)
        {
            return _borrowingRepository.GetById(id);
        }
        public void AddBorrowing(Borrowing borrowing)
        {
            _borrowingRepository.Insert(borrowing);
        }
        public void UpdateBorrowing(Borrowing borrowing)
        {
            _borrowingRepository.Update(borrowing);
        }
        public void DeleteBorrowing(int id)
        {
            var borrowing = _borrowingRepository.GetById(id);
            if (borrowing != null)
            {
                _borrowingRepository.Delete(borrowing);
            }
        }

    }
}
