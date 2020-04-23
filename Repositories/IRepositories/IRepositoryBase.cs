using System;
using System.Linq;
using System.Linq.Expressions;

namespace FitnessWeb_API.Repositories.IRepositories
{
    public interface IRepositoryBase<T>
    {
         IQueryable<T> FindAll();
         IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
         IQueryable<T> Create(T entity);
         IQueryable<T> Update(T entity);
         void Delete(T entity);
    }
}