using System.Collections.Generic;
using KotasProject.Models;
using Microsoft.AspNetCore.Mvc;
using PokeAPI_Project.Controllers.Models.Response;
using PokeAPI_Project.Services.Interfaces;

namespace KotasProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        //Get a single pokemon

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetPokemon([FromQuery] int? id, string name)
        {
            PokemonResponse pokemonResponse = _pokemonService.GetPokemon(id, name);

            return Ok(pokemonResponse);
        }

        //Get a multiple random pokemons

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetRandomPokemon()
        {
            List<PokemonResponse> pokemonList = _pokemonService.GetRandomPokemon();

            return Ok(pokemonList);
        }

        //Capture Pokemon

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CapturePokemon([FromBody] PokemonTrainer pokemonTrainer)
        {
            _pokemonService.CapturePokemon(pokemonTrainer);

            return Ok("Pokemon has captured!");
        }
    }
}