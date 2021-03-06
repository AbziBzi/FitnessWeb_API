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

        // api/exercises/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteExercise(int id)
        {
            var performedExercise = _repository.PerformingExercises.GetExercise(c => c.IdAtliekamasPratimas.Equals(id)).FirstOrDefault();
            if (performedExercise == null)
                return NotFound("PerformedExercise not found");
            _repository.PerformingExercises.DeleteExercise(performedExercise);

            return Ok();
        }

        // api/exercises
        [HttpGet]
        public ActionResult<IEnumerable<PerformingExerciseGetModel>> GetAllExercises()
        {
            var exercises = _repository.PerformingExercises.GetExercises();
            var mappedExercises = new List<PerformingExerciseGetModel>();
            foreach (var exercise in exercises)
                mappedExercises.Add(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(exercise));
            
            return Ok(mappedExercises);
        }

        // api/exercises
        [HttpPost]
        public ActionResult<PerformingExerciseGetModel> CreatePerformingExercise([FromBody] PerformingExerciseCreateModel exercise)
        {
            if (exercise == null)
                return BadRequest("PerformingExercise object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid PerformingExercise data");
            
            var savedExercise = _repository.PerformingExercises.CreatePerformingExercise(exercise);
            if (savedExercise == null)
                return BadRequest("PerformingExercise could not be saved");
            return Ok(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(savedExercise));
        }

        // api/exercises/rating/{exerciseID}
        [HttpGet("rating/{id}")]
        public ActionResult<PerformedExerciseRatingGetModel> GetRating(int id)
        {
            var rating = _repository.PerformingExercises.CheckRating(id);
            if (rating == null)
                return NotFound("Rating or Exercise not found");
            return Ok(rating);
        }

        // api/exercises/rating/{exerciseID}
        [HttpPut("rating/insert/{id}")]
        public ActionResult<PerformingExerciseGetModel> InsertRating(int id, [FromBody]PerformedExerciseRatingCreateModel rating)
        {
            if (rating == null)
                return BadRequest("Rating data is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid Rating data");
            var updatedExercise = _repository.PerformingExercises.InsertRating(id, rating);
            if (updatedExercise == null)
                return BadRequest("Rating could not be created");
            return Ok(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(updatedExercise));
        }

        // api/exercises/rating/{exerciseID}
        [HttpPut("rating/update/{id}")]
        public ActionResult<PerformingExerciseGetModel> UpdateRating(int id, [FromBody]PerformedExerciseRatingCreateModel rating)
        {
            if (rating == null)
                return BadRequest("Rating data is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid Rating data");
            var updatedExercise = _repository.PerformingExercises.UpdateRating(id, rating);
            if (updatedExercise == null)
                return BadRequest("Rating could not be created");
            return Ok(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(updatedExercise));
        }

        // api/exercise/rating/delete/{exerciseID}
        [HttpPut("rating/delete/{id}")]
        public ActionResult<PerformingExerciseGetModel> DeleteRating(int id)
        {
            var updatedExercise = _repository.PerformingExercises.DeleteRating(id);
            if (updatedExercise == null)
                return BadRequest("Rating could not be created");
            return Ok(_mapper.Map<AtliekamasPratimas, PerformingExerciseGetModel>(updatedExercise));
        }
    }
}