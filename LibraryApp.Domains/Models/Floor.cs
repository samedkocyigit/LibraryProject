using LibraryApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domains.Models
{
    public class Floor:BaseEntity
    {
        public int FloorId { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
