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
    }
}