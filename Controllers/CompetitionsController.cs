using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;
using FitnessWeb_API.Mapping.Models;

namespace FitnessWeb_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionsController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CompetitionsController(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repository = repositoryWrapper;
        }

        // /api/competitions
        [HttpGet]
        public ActionResult<IEnumerable<CompetitionGetModel>> GetAllCompetitions()
        {
            var competitions = _repository.Competition.GetAllCompetitions();
            var mappedCompetitions = new List<CompetitionGetModel>();
            foreach (var competition in competitions)
                mappedCompetitions.Add(_mapper.Map<Varzybos, CompetitionGetModel>(competition));

            return Ok(mappedCompetitions);
        }

        // /api/competitions/{id}
        [HttpGet("{id}")]
        public ActionResult<CompetitionGetModel> GetCompetition(int id)
        {
            var competition = _repository.Competition.GetCompetition(c => c.IdVarzybos.Equals(id)).FirstOrDefault();
            if (competition == null)
                return NotFound("Competition not found");

            return Ok(_mapper.Map<Varzybos, CompetitionGetModel>(competition));
        }

        // /api/competitions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCompetition(int id)
        {
            try
            {
                var competition = _repository.Competition.GetCompetition(c => c.IdVarzybos.Equals(id)).FirstOrDefault();
                if (competition == null)
                    return NotFound("Competition not found");

                _repository.Competition.DeleteCompetition(competition);
                _repository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:\n{ex.Message}");
            }
        }

        // /api/competitions
        [HttpPost]
        public ActionResult<CompetitionGetModel> CreateCompetition([FromBody] CompetitionCreateModel competition)
        {
            try
            {
                if (competition == null)
                    return BadRequest("Competition object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid competition data");
                var savedCompetition = _repository.Competition.CreateCompetition(competition);
                if (savedCompetition == null)
                    return BadRequest("Competition could not be saved");
                var newCompetitor = _repository.Competitor.CreateCompetitor(savedCompetition.FkNaudotojasId, savedCompetition.IdVarzybos);
                if (newCompetitor == null)
                    return BadRequest("User is already participating in competition");

                var finalCompetition = _repository.Competition.GetCompetition(c => c.IdVarzybos.Equals(savedCompetition.IdVarzybos)).FirstOrDefault();
                return Ok(_mapper.Map<Varzybos, CompetitionGetModel>(finalCompetition));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:\n{ex.Message}");
            }
        }

        // api/competitions/{id}
        [HttpPut("{id}")]
        public ActionResult<CompetitionGetModel> UpdateCompetition(int id, [FromBody] CompetitionUpdateModel competition)
        {
            try
            {
                if (competition == null)
                    return BadRequest("Competition object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var changed = _repository.Competition.UpdateCompetition(competition, id);
                if (changed == null)
                    return BadRequest("Competition with given ID not found");
                return Ok(competition);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:\n{ex.Message}");
            }
        }

        // api/competitions/join/{competitionId}/{userId}
        [HttpPut("join/{competitionid}/{userId}")]
        public ActionResult<CompetitionGetModel> JoinCompetition(int competitionId, int userId)
        {
            var user = _repository.User.GetUser(c => c.IdNaudotojas.Equals(2)).FirstOrDefault();
            if (user == null)
                return NotFound("User not Found");
            var competition = _repository.Competition.GetCompetition(c => c.IdVarzybos.Equals(competitionId)).FirstOrDefault();
            if (competition == null)
                return NotFound("Competition not found");

            var newCompetitor = _repository.Competitor.CreateCompetitor(2, competitionId);
            if (newCompetitor == null)
                return BadRequest("User is already participating in competition");

            competition = _repository.Competition.GetCompetition(c => c.IdVarzybos.Equals(competitionId)).FirstOrDefault();

            return Ok(_mapper.Map<Varzybos, CompetitionGetModel>(competition));
        }
    }
}