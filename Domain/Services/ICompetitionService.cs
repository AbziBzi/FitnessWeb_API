using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessWeb_API.Domain.Models;

namespace FitnessWeb_API.Domain.Services
{
    public interface ICompetitionService
    {
         Task<IEnumerable<Varzybos>> ListAsync();
    }
}