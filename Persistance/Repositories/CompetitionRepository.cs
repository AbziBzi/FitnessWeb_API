using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessWeb_API.Domain.Models;
using FitnessWeb_API.Domain.Repositories;
using FitnessWeb_API.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb_API.Persistance.Repositories
{
    public class CompetitionRepository : BaseRepository, ICompetitionRepository
    {
        public CompetitionRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Varzybos>> ListAsync()
        {
            return await _context.Varzybos
                            .ToListAsync();
        }
    }
}