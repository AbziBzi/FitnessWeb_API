using System.Collections.Generic;
using AutoMapper;
using FitnessWeb_API.Mapping.Models;
using FitnessWeb_API.Models;
using FitnessWeb_API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWeb_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportProgramsController :Controller
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
    }
}