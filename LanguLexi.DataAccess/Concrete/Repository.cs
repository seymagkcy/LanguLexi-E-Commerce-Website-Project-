using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using LanguLexi.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LanguLexi.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T: class, IEntityLanguLexi, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public List<T> RetrieveAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<List<T>> RetrieveAllAsync()
        {
            return await  _dbSet.AsNoTracking().ToListAsync();
        }

        public List<T> RetrieveAll(Expression<Func<T, bool>> expression) 
        {
            return _dbSet.Where(expression).AsNoTracking().ToList();

        }

        public async Task<List<T>> RetrieveAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().ToListAsync();
        }

        public T Retrieve(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);

        }

        public async Task<T> RetrieveAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> RetrieveQueryable()
        {
            return _dbSet;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        } 

        public async Task AddAsync(T entity)
        {
             await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
       
    }
}
