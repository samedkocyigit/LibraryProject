using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class FloorRepository:GenericRepository<Floor>,IFloorRepository
    {
        private readonly LibraryContext _context;
        public FloorRepository(LibraryContext context):base(context)
        {
            _context = context;
            
        }
    }
}
