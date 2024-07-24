using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class AddressRepository:GenericRepository<Address>,IAddressRepository
    {
        private readonly LibraryContext _context;
        public AddressRepository(LibraryContext context):base(context)
        {
            _context= context;
        }
    }
}
