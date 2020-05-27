using System;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class UserRepository
    {
        private AppDbContext _repository;
        
        public UserRepository(AppDbContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IQueryable<Naudotojas> GetUser(Expression<Func<Naudotojas, bool>> expression)
        {
            return _repository.Set<Naudotojas>()
                              .Where(expression)
                              .AsNoTracking();
        }
    }
}