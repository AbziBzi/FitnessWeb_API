using FitnessWeb_API.Repositories.IRepositories;

namespace FitnessWeb_API.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _context;
        private CompetitionRepository _competition;

        public RepositoryWrapper(AppDbContext repositoryContext)
        {
            _context = repositoryContext;
        }
 
        public void Save()
        {
            _context.SaveChanges();
        }
        public CompetitionRepository Competition {
            get {
                if(_competition == null)
                    _competition = new CompetitionRepository(_context);
                return _competition;
            }
        }
    }
}