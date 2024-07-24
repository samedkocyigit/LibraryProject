using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class MemberRepository:GenericRepository<Member>, IMemberRepository
    {
        private readonly LibraryContext _context;
        public MemberRepository(LibraryContext context):base(context)
        {
            _context = context;
        }
    }
}
