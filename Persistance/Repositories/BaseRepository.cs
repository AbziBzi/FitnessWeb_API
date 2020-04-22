using FitnessWeb_API.Persistance.Contexts;

namespace FitnessWeb_API.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}