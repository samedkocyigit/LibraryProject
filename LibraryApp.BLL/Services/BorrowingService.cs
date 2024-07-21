using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class BorrowingService
    {
        private readonly IGenericRepository<Borrowing> _borrowingRepository;

        public BorrowingService( IGenericRepository<Borrowing> borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;            
        }

        public IEnumerable<Borrowing> GetAllBorrowings()
        {
            return _borrowingRepository.GetAll();
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
