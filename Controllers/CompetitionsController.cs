using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessWeb_API.Domain.Models;
using FitnessWeb_API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWeb_API.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionsController : Controller 
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionsController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Varzybos>> GetAllAsync()
        {
            var competitions = await _competitionService.ListAsync();

            return competitions;
        }
    } 
}