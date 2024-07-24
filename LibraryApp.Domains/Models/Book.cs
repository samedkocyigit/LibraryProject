using LibraryApp.Core;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryApp.Domains.Models
{
    public class Book:BaseEntity    
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public  Author Author { get; set; }

        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }
        public bool IsBorrowed { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
