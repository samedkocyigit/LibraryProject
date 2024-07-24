using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IBorrowingService
    {
        IEnumerable<Borrowing> GetAllBorrowings();
        Borrowing GetBorrowingById(int id);
        void AddBorrowing(Borrowing borrowing);
        void UpdateBorrowing(Borrowing borrowing);
        void DeleteBorrowing(int id);
        void BorrowBook(int memberId, int bookId);
        void ReturnBook(int memberId, int bookId);
        IEnumerable<Borrowing> GetBorrowingsByMember(int memberId);
        IEnumerable<Borrowing> GetBorrowingsByBook(int bookId);
    }
}
