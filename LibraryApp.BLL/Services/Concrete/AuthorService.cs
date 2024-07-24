using LibraryApp.BLL.Services.Abstract;
using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }
        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
           return _authorRepository.GetBooksByAuthor(authorId);
        }
        public Author GetAuthorByName(string name)
        {
            return _authorRepository.GetAuthorByName(name);
        } 
        public Author GetAuthorById(int id) 
        { 
            return _authorRepository.GetById(id);
        }

        public void AddAuthor(Author author) 
        {
            _authorRepository.Insert(author);
        }
        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
        public void DeleteAuthor(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author!=null)
            {
                _authorRepository.Delete(author);
            }
        }

    }
}
