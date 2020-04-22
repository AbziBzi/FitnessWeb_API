using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessWeb_API.Domain.Models;
using FitnessWeb_API.Domain.Repositories;
using FitnessWeb_API.Domain.Services;

namespace FitnessWeb_API.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            this._competitionRepository = competitionRepository;
        }

        public async Task<IEnumerable<Varzybos>> ListAsync()
        {
            return await _competitionRepository.ListAsync();
        }
    }
}