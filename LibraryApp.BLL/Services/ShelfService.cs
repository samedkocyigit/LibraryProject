using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class ShelfService
    {
        private readonly IGenericRepository<Shelf> _shelfRepository;
        public ShelfService(IGenericRepository<Shelf> shelfRepository) 
        {
            _shelfRepository = shelfRepository;
        }
        public IEnumerable<Shelf> GetAllShelves()
        {
            return _shelfRepository.GetAll();
        }
        public Shelf GetShelfById(int id)
        {
            return _shelfRepository.GetById(id);
        }

        public void AddShelf(Shelf shelf)
        {
            _shelfRepository.Insert(shelf);
        }
        public void UpdateShelf(Shelf shelf)
        {
            _shelfRepository.Update(shelf);
        }

        public void DeleteShelf(int id)
        {
            var shelf= _shelfRepository.GetById(id);
            if (shelf != null)
            {
                _shelfRepository.Delete(shelf);
            }
        }

    }
}
