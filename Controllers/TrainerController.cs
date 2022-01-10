using System.Collections.Generic;
using System.Linq;
using KotasProject.Data;
using KotasProject.Models;
using KotasProject.Models.Trainer;
using Microsoft.AspNetCore.Mvc;
using PokeAPI_Project.Controllers.ExternalRequest;
using PokeAPI_Project.Controllers.Mapping;
using PokeAPI_Project.Controllers.Models.Request;
using PokeAPI_Project.Services.Interfaces;

namespace PokeAPI_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TrainerMapper _mapper;
        private readonly ITrainerService _trainerService;

        public TrainerController(DataContext context, ITrainerService trainerService)
        {
            _context = context;
            _mapper = new TrainerMapper();
            _trainerService = trainerService;
        }


        //Create new pokemon trainer

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CreateNewTrainer([FromBody] TrainerRequest trainerRequest)
        {
            Trainer trainer = _mapper.Map(trainerRequest);

            _trainerService.NewTrainer(trainer);

            return Ok("New pokemon trainer has successfully created!");
        }

        //Get a multiple captured pokemons

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAllCaptured([FromQuery] int trainerId)
        {
            List<Pokemon> pokemonList = _trainerService.GetAllCaptured(trainerId);

            return Ok(pokemonList);
        }

    }
}