using FitnessWeb_API.Repositories.IRepositories;

namespace FitnessWeb_API.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _context;
        private CompetitionRepository _competition;
        private UserRepository _user;
        private CompetitorRepository _competitor;

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

        public UserRepository User {
            get {
                if(_user == null)
                    _user = new UserRepository(_context);
                return _user;
            }
        }

        public CompetitorRepository Competitor {
            get {
                if(_competitor == null)
                    _competitor = new CompetitorRepository(_context);
                return _competitor;
            }
        }
    }
}