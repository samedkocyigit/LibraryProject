using LibraryApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryApp.Domains.Models
{
    public class Member:BaseEntity
    {
        public int MemberId { get; set; }
        [EnumDataType(typeof(MemberRole))]
        public string Role { get; set; } = MemberRole.User.ToString();
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
