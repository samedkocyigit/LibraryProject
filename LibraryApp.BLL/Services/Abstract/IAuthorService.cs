using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        Author GetAuthorById(int id);
        Author GetAuthorByName(string name);
        void AddAuthor (Author author);
        void UpdateAuthor (Author author);
        void DeleteAuthor (int id);

    }
}
