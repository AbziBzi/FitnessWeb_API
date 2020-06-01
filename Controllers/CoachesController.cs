using AutoMapper;
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
    }
}