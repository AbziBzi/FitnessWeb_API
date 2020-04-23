using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;

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
        public ActionResult<IEnumerable<Varzybos>> GetAllCompetitions()
        {
            var competitions = _repository.Competition.FindAll();
            
            return Ok(competitions);
        }

        // /api/competitions/{id}
        [HttpGet("{id}")]
        public ActionResult<Varzybos> GetCompetitionById(int id)
        {
            var competition = _repository.Competition.FindByCondition(c => c.IdVarzybos.Equals(id)).FirstOrDefault();
            if(competition == null)
                return NotFound("Competition not found");

            return Ok(competition);
        }

        // /api/competitions
        // [HttpPost]
        // public IActionResult<Varzybos> CreateCompetition([FromBody] Varzybos)

        // /api/competitions/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCompetition(int id)
        {
            try 
            {
                var competition = _repository.Competition.FindByCondition(c => c.IdVarzybos.Equals(id)).FirstOrDefault();
                if(competition == null)
                    return NotFound("Competition not found");
                
                _repository.Competition.Delete(competition);
                _repository.Save();
                
                return Ok(); 
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error:\n{ex.Message}");
            }
        }
    } 
}