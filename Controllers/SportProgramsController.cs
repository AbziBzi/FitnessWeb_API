using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWeb_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportProgramsController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public SportProgramsController(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        // /api/sportPrograms
        [HttpGet]
        public ActionResult<IEnumerable<SportProgramGetModel>> GetAllPrograms()
        {
            var sportPrograms = _repository.SportProgram.GetAllPrograms();
            if (sportPrograms == null || !sportPrograms.Any())
                return NotFound("No Sport Programs found");
            var mappedSportPrograms = new List<SportProgramGetModel>();
            foreach (var program in sportPrograms)
                mappedSportPrograms.Add(_mapper.Map<SportoPrograma, SportProgramGetModel>(program));

            return Ok(mappedSportPrograms);
        }

        // api/sportPrograms/{id}
        [HttpGet("{id}")]
        public ActionResult<SportProgramGetModel> GetSportProgram(int id)
        {
            var sportProgram = _repository.SportProgram
                .GetSportProgram(c => c.IdSportoPrograma.Equals(id)).FirstOrDefault();
            if (sportProgram == null)
                return NotFound("Sport Program not found");
            return Ok(_mapper.Map<SportoPrograma, SportProgramGetModel>(sportProgram));
        }

        // api/sportPrograms/coach/{coachID}
        [HttpGet("coach/{id}")]
        public ActionResult<IEnumerable<SportProgramGetModel>> GetAllTrainerPrograms(int id)
        {
            var sportPrograms = _repository.SportProgram.GetAllTrainerPrograms(id);
            if (sportPrograms == null || !sportPrograms.Any())
                return NotFound("No Sport Programs found");
            var mappedPrograms = new List<SportProgramGetModel>();
            foreach (var program in sportPrograms)
                mappedPrograms.Add(_mapper.Map<SportoPrograma, SportProgramGetModel>(program));
            
            return Ok(mappedPrograms);
        }

        // api/sportPrograms
        [HttpPost]
        public ActionResult<SportProgramGetModel> CreateSportProgram([FromBody]SportProgramCreateModel program)
        {
            if (program == null)
                return BadRequest("SportProgram object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid sportProgram object");
            
            var savedSportProgram = _repository.SportProgram.InsertProgram(program);
            if (savedSportProgram == null)
                return BadRequest("New SportProgram could not be saved");
            return Ok(_mapper.Map<SportoPrograma, SportProgramGetModel>(savedSportProgram));
        }

        // api/sportPrograms{id}
        [HttpPut("{id}")]
        public ActionResult<SportProgramGetModel> EditSportProgram(int id, [FromBody]SportProgramUpdateModel program)
        {
            if (program == null)
                return BadRequest("SportProgram object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid sportProgram object");
            
            var updatedSportProgram = _repository.SportProgram.UpdateProgram(id, program);
            if (updatedSportProgram == null)
                return NotFound("SportProgram with given ID could not be found");
            return Ok(_mapper.Map<SportoPrograma, SportProgramGetModel>(updatedSportProgram));
        }

        // /api/sportProgram/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProgram(int id)
        {
            var program = _repository.SportProgram.DeleteProgram(id);
            if (program == null)
                return NotFound("SportProgram with given ID not found");
            return Ok();
        }
    }
}