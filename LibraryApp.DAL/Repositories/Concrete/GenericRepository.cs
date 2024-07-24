using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Repositories.Concrete
{
    public class GenericRepository<T> : Abstract.GenericRepository<T> where T : class
    {
        private readonly LibraryContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryContext context)
        {
            _context = context;
            _dbSet= context.Set<T>();
        }

        public IEnumerable<T> GetAll() 
        { 
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State= EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State== EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
        } 
    }
}
