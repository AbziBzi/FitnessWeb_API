using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessWeb_API.Domain.Models;

namespace FitnessWeb_API.Domain.Repositories
{
    public interface ICompetitionRepository
    {
         Task<IEnumerable<Varzybos>> ListAsync();
    }
}