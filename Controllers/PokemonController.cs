using System;
using System.Collections.Generic;
using KotasProject.Controllers.Utils;
using KotasProject.Data;
using KotasProject.Models;
using Microsoft.AspNetCore.Mvc;
using PokeAPI_Project.Controllers.ExternalRequest;
using PokeAPI_Project.Controllers.Mapping;
using PokeAPI_Project.Controllers.Models.Response;

namespace KotasProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly PokemonMapper _mapper;

        public PokemonController(DataContext context)
        {
            _context = context;
            _mapper = new PokemonMapper();
        }

        //Get a single pokemon

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetPokemon([FromQuery] int? id, string name)
        {

            Pokemon pokemon = new Pokemon();

            if (id == null)
                pokemon = PokeAPI.GetPokemonByName(name);

            if (String.IsNullOrEmpty(name))
                pokemon = PokeAPI.GetPokemonById(id);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            PokemonResponse response = _mapper.Map(pokemon);

            return Ok(response);
        }

        //Get a multiple random pokemons

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetRandomPokemon()
        {
            List<PokemonResponse> pokemonList = new List<PokemonResponse>();
            Pokemon pokemon = new Pokemon();

            while (pokemonList.Count < 10)
            {
                Random RandomPokemonId = new Random();

                int pokemonId = RandomPokemonId.Next(1, 898);

                pokemon = PokeAPI.GetPokemonById(pokemonId);

                pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

                PokemonResponse response = _mapper.Map(pokemon);

                pokemonList.Add(response);
            }

            return Ok(pokemonList);
        }

        //Capture Pokemon

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CapturePokemon([FromBody] PokemonTrainer pokemonTrainer)
        {
            Pokemon pokemon = new Pokemon();

            pokemon = PokeAPI.GetPokemonById(pokemonTrainer.PokemonId);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            pokemon.TrainerId = pokemonTrainer.TrainerId;

            _context.Add(pokemonTrainer);
            _context.Add(pokemon);
            _context.SaveChanges();

            return Ok("Pokemon has captured!");
        }
    }
}