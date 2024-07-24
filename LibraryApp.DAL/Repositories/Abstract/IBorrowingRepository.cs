using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Abstract
{
    public interface IBorrowingRepository:GenericRepository<Borrowing>
    {
        IEnumerable<Borrowing> GetBorrowingsByMember(int memberId);
        IEnumerable<Borrowing> GetBorrowingsByBook(int bookId);
    
    }
}
