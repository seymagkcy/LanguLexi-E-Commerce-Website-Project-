using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LanguLexi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguLexi.DataAccess.Abstract
{
    public interface IRepository<T> where T: class, IEntityLanguLexi, new()
    {
        List<T> RetrieveAll();

        List<T> RetrieveAll(Expression<Func<T, bool>> expression);

        T Retrieve(Expression<Func<T, bool>> expression);

        T Find(int id);

        IQueryable<T> RetrieveQueryable();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        int SaveChanges();

        
        // Asenkron metotlar

        Task<List<T>> RetrieveAllAsync();

        Task<List<T>> RetrieveAllAsync(Expression<Func<T, bool>> expression);

        Task<T> RetrieveAsync(Expression<Func<T, bool>> expression);

        Task<T> FindAsync(int id);

        Task AddAsync(T entity);

        Task<int> SaveChangesAsync();



    }
}
