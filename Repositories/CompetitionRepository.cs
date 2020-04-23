using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;

namespace FitnessWeb_API.Repositories
{
    public class CompetitionRepository : RepositoryBase<Varzybos>, ICompetitionRepository
    {
        public CompetitionRepository(AppDbContext repositoryContext) : base(repositoryContext)
        { }
        
    }
}