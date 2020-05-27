using System;
using System.Linq;
using System.Linq.Expressions;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Repositories
{
    public class CompetitorRepository
    {
        private AppDbContext _repository;

        public CompetitorRepository(AppDbContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IQueryable<VarzybuDalyvis> GetCompetitor(Expression<Func<VarzybuDalyvis, bool>> expression)
        {
            return _repository.Set<VarzybuDalyvis>()
                              .Where(expression)
                              .AsNoTracking();
        }

        public VarzybuDalyvis CreateCompetitor(int userId, int competitionId)
        {
            var foundCompetition = _repository.Set<Varzybos>().
                FirstOrDefault(o => o.IdVarzybos.Equals(competitionId));
            if(foundCompetition == null)
                return null;

            var foundUser = _repository.Set<Naudotojas>().
                FirstOrDefault(o => o.IdNaudotojas.Equals(userId));
            if(foundUser == null)
                return null;
            
            var foundCompetitor = GetCompetitor(c => c.FkNaudotojasId.Equals(userId) &&
                                                c.FkVarzybosId.Equals(competitionId))
                                                .FirstOrDefault();
            if (foundCompetitor != null)
                return null;
            
            VarzybuDalyvis newCompetitor = new VarzybuDalyvis();
            newCompetitor.FkNaudotojasId = userId;
            newCompetitor.FkVarzybosId = competitionId;

            _repository.Set<VarzybuDalyvis>().Add(newCompetitor);
            _repository.SaveChanges();

            return newCompetitor;
        }
    }
}