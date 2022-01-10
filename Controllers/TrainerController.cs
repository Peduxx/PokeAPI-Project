using System.Collections.Generic;
using System.Linq;
using KotasProject.Data;
using KotasProject.Models;
using KotasProject.Models.Trainer;
using Microsoft.AspNetCore.Mvc;
using PokeAPI_Project.Controllers.ExternalRequest;
using PokeAPI_Project.Controllers.Mapping;
using PokeAPI_Project.Controllers.Models.Request;

namespace PokeAPI_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TrainerMapper _mapper;

        public TrainerController(DataContext context)
        {
            _context = context;
            _mapper = new TrainerMapper();
        }


        //Create new pokemon trainer

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CreateNewTrainer([FromBody] TrainerRequest trainerRequest)
        {
            Trainer trainer = _mapper.Map(trainerRequest);

            _context.Add(trainer);
            _context.SaveChanges();

            return Ok("New pokemon trainer has successfully created!");
        }

        //Get a multiple captured pokemons

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAllCaptured([FromQuery] int trainerId)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            Pokemon pokemon = new Pokemon();

            IEnumerable<PokemonTrainer> pokemonTrainerList = _context.PokemonTrainer.ToList().Where(pt => pt.TrainerId == trainerId);

            foreach (PokemonTrainer pokemonTrainer in pokemonTrainerList)
            {
                pokemon = PokeAPI.GetPokemonById(pokemonTrainer.PokemonId);

                pokemon.TrainerId = pokemonTrainer.TrainerId;

                pokemonList.Add(pokemon);
            }

            return Ok(pokemonList);
        }

    }
}