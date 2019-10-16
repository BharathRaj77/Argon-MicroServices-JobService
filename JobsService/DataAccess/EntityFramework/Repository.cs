using DataAccess.EntityFramework.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EntityFramework
{
    // Not using at the moment - need to modify 
    public class Repository<T> : IRepository<T> where T : class
    {
        public JobContext _jobContext; 

        internal JobContext jobContext
        {
            get
            {
                if (_jobContext == null)
                    _jobContext = new JobContext(new DbContextOptions<JobContext>()); // check this
                return _jobContext;
            }
            set
            {
                _jobContext = value;
            }
        }
        public T Add(T entity)
        {
            if (entity != null)
            {
                _jobContext.Set<T>().Add(entity);
            }
            return entity;
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                _jobContext.Set<T>().Remove(entity);
            }
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            if (entities.Count() > 0)
            {
                _jobContext.Set<T>().RemoveRange(entities);
            }
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? null : _jobContext.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? null : _jobContext.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _jobContext.Set<T>().ToList();
        }

        public int Save()
        {
            return _jobContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _jobContext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
