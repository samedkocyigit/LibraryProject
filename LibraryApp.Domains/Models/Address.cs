using LibraryApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domains.Models
{
    public class Address:BaseEntity
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string AddressText { get; set; }
        public string PostalCode { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}
