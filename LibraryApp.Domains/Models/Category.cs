using LibraryApp.Core;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domains.Models
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        public ICollection<Shelf> Shelves { get; set; }

    }
}
