using System.Linq;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class SportProgramRepository
    {
        private AppDbContext _repository;

        public SportProgramRepository(AppDbContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IQueryable<SportoPrograma> GetAllPrograms()
        {
            return _repository.Set<SportoPrograma>()
                              .Include(o => o.FkTreneris)
                                    .ThenInclude(o => o.IdNaudotojasNavigation)
                              .Include(o => o.SportoProgramosPratimas)
                                    .ThenInclude(o => o.FkPratimas)
                              .AsNoTracking();
        }
    }
}