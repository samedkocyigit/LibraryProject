using LibraryApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domains.Models
{
    public class Member:BaseEntity
    {
        public int MemberId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime MembershipDate { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
