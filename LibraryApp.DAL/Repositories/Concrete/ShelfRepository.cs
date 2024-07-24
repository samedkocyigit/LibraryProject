using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class ShelfRepository:GenericRepository<Shelf>, IShelfRepository
    {
        private readonly LibraryContext _context;
        public ShelfRepository(LibraryContext context):base(context)
        {
            _context = context;
        }
    }
}
