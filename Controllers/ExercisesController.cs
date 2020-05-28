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
    public class ExercisesController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ExercisesController(IMapper mapper, IRepositoryWrapper repositoryWraper)
        {
            _repository = repositoryWraper;
            _mapper = mapper;
        }

        // /api/exercises/{userID}
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<PerformingExerciseGetModel>> GetCompletedExercisesForUser(int userId)
        {
            var currentUser = _repository.User.GetUser(c => c.IdNaudotojas.Equals(1)).FirstOrDefault();
            if (currentUser == null)
                return NotFound("CurrentUser not found");
            var performingExercises = _repository.PerformingExercises.GetCompletedExercisesForUser(currentUser.IdNaudotojas);
            var mappedExecises = new List<PerformingExerciseGetModel>();
            foreach (var exercise in performingExercises)
                mappedExecises.Add(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(exercise));
            return Ok(mappedExecises);
        }
    }
}