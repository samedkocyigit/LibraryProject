using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class BorrowingRepository : GenericRepository<Borrowing>, IBorrowingRepository
    {
        private readonly LibraryContext _context;
        public BorrowingRepository(LibraryContext context):base(context) 
        {
            _context = context;
        }
        public IEnumerable<Borrowing> GetBorrowingsByMember(int memberId)
        {
            return _context.Borrowings.Where(b=>b.MemberId == memberId);
        }

        public IEnumerable<Borrowing> GetBorrowingsByBook(int bookId) 
        {
            return _context.Borrowings.Where(b => b.BookId == bookId);
        }
    }
}
