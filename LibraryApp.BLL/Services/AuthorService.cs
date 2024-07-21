using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class AuthorService
    {
        private readonly IGenericRepository<Author> _authorRepository;

        public AuthorService(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
            
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
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
