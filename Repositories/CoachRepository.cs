using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class CoachRepository
    {
        private AppDbContext _repository;
        public CoachRepository(AppDbContext repositoryContext)
        { 
            _repository = repositoryContext;
        }

        public IQueryable<Treneris> GetCoachesInPriceRange(PriceIntervalModel priceInterval)
        {
            return _repository.Set<Treneris>()
                .Where(o => o.Kaina >= priceInterval.Min && o.Kaina <= priceInterval.Max)
                .Include(o => o.IdNaudotojasNavigation)
                .Include(o => o.Reitingas);
        }
    }
}