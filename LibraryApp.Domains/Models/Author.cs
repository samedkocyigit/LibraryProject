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
    public class Author:BaseEntity
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
