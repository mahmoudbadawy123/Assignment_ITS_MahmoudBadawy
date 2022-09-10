using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity.Core.Objects;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        List<TEntity> AddRange(List<TEntity> list);
        TEntity Find(params object[] predicate);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        TResult Max<TResult>(Expression<Func<TEntity, TResult>> selector);
        int Count(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity Remove(TEntity entity);
        List<TEntity> RemoveRange(List<TEntity> list);
        bool Any(Expression<Func<TEntity, bool>> predicate);

    }
}