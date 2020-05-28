using System.Linq;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class PerformingExercisesRepository
    {
        private readonly AppDbContext _repository;

        public PerformingExercisesRepository(AppDbContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IQueryable<AtliekamasPratimas> GetCompletedExercisesForUser(int userId)
        {
            return _repository.Set<AtliekamasPratimas>()
                .Where(o => o.FkSportininkasId.Equals(userId))
                .Include(o => o.FkPratimas)
                .Include(o => o.FkTreneris)
                .AsNoTracking();
        }
    }
}