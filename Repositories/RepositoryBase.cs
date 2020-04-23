using System;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext RepositoryContext { get; set; }

        public RepositoryBase(AppDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> Create(T entity)
        {
            var a = this.RepositoryContext.Set<T>().Add(entity);
            return (IQueryable<T>)entity;
        }

        public IQueryable<T> Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            return (IQueryable<T>)entity;
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}