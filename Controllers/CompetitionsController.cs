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
    } 
}