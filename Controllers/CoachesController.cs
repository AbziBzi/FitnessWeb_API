using System;
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
    public class CoachesController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CoachesController(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
            _mapper = mapper;
        }

        // /api/coaches/rekomended
        [HttpGet("recomended")]
        public ActionResult<IEnumerable<Treneris>> GetRecomendedCoaches([FromBody] PriceIntervalModel priceInterval)
        {
            if (priceInterval == null)
                return BadRequest("PriceInterval object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid PriceInterval object");
            var coaches = _repository.Coach.GetCoachesInPriceRange(priceInterval);
            if (coaches == null || !coaches.Any())
                return NotFound("No coaches found in given price interval");
            var coachesPriority = new Dictionary<Treneris, double>();
            // set initial coach priority => 1
            foreach (var coach in coaches)
                coachesPriority.Add(coach, SetInitialCoachPriority());
            foreach (var key in coachesPriority.Keys.ToList())
                coachesPriority[key] = ApplyCriterialWeightFunctionsToPriority(key, coachesPriority[key]);
            var sorted = SortCoachesByPriority(coachesPriority);
            return Ok(sorted);
        }

        private static List<Treneris> SortCoachesByPriority(Dictionary<Treneris, double> coaches)
        {
            var dict =  coaches.OrderByDescending(r=> r.Value).ToDictionary(k => k.Key, v => v.Value);
            List<Treneris> keyList = new List<Treneris>(dict.Keys);
            return keyList;
        }

        private static int SetInitialCoachPriority()
        {
            return 1;
        }

        private double ApplyCriterialWeightFunctionsToPriority(Treneris coach, double priority)
        {
            var currentUser = _repository.User.GetCurrentUser();
            double newPriority = 1;
            newPriority = priority/Math.Pow(coach.Kaina, 2);
            newPriority = newPriority * Math.Log((double)currentUser.Lygis);
            newPriority = newPriority * Math.Pow(GetCoachRating(coach), 3);
            return newPriority;
        }

        private double GetCoachRating(Treneris coach)
        {
            if (coach.Reitingas == null || !coach.Reitingas.Any())
                return 1;
            double sum = 0;
            foreach (var rating in coach.Reitingas)
            {
                sum += (double)rating.Ivertinimas;
            }
            return sum/coach.Reitingas.Count;
        }
    }
}