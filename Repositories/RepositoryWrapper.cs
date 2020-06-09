using FitnessWeb_API.Repositories.IRepositories;

namespace FitnessWeb_API.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _context;
        private CompetitionRepository _competition;
        private UserRepository _user;
        private CompetitorRepository _competitor;
        private SportProgramRepository _sportProgram;
        private PerformingExercisesRepository _performingExercises;
        private CoachRepository _coach;

        public RepositoryWrapper(AppDbContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public CompetitionRepository Competition
        {
            get
            {
                if (_competition == null)
                    _competition = new CompetitionRepository(_context);
                return _competition;
            }
        }

        public UserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context);
                return _user;
            }
        }

        public CompetitorRepository Competitor
        {
            get
            {
                if (_competitor == null)
                    _competitor = new CompetitorRepository(_context);
                return _competitor;
            }
        }

        public SportProgramRepository SportProgram
        {
            get
            {
                if (_sportProgram == null)
                    _sportProgram = new SportProgramRepository(_context);
                return _sportProgram;
            }
        }

        public PerformingExercisesRepository PerformingExercises
        {
            get 
            {
                if (_performingExercises == null)
                    _performingExercises = new PerformingExercisesRepository(_context);
                return _performingExercises;
            }
        }

        public CoachRepository Coach
        {
            get 
            {
                if (_coach == null)
                    _coach = new CoachRepository(_context);
                return _coach;
            }
        }
    }
}