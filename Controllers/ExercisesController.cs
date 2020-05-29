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

        // /api/exercises/performed/{userID}
        [HttpGet("performed/{userId}")]
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

        // api/exercises/{id}
        [HttpPut("{id}")]
        public ActionResult<PerformingExerciseGetModel> UpdateExercise(int id, [FromBody] PerformingExerciseUpdateModel exercise)
        {
            if (exercise == null)
                return BadRequest("PerformingExercise object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");
            
            var changed = _repository.PerformingExercises.UpdateExercise(id, exercise);
            if (changed == null)
                return BadRequest("Competition with given ID not found");
            return Ok(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(changed));
        }

        // api/exercises/{id}
        [HttpGet("{id}")]
        public ActionResult<PerformingExerciseGetModel> GetExercise(int id)
        {
            var exercise = _repository.PerformingExercises.GetExercise(C => C.IdAtliekamasPratimas.Equals(id)).FirstOrDefault();
            if (exercise == null)
                return NotFound("PerformingExercise not found");
            
            return Ok(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(exercise));
        }
    }
}