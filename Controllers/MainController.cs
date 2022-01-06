using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using KotasProject.Controllers.Mapping;
using KotasProject.Controllers.Utils;
using KotasProject.Data;
using KotasProject.Models;
using KotasProject.Models.Trainer;
using Microsoft.AspNetCore.Mvc;

namespace KotasProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private readonly DataContext _context;
        private readonly PokemonMapper _mapper;

        public MainController(DataContext context)
        {
            _context = context;
            _mapper = new PokemonMapper();
        }

        //Get a single pokemon

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetPokemon([FromQuery] int id)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync(
                           $"https://pokeapi.co/api/v2/pokemon/{id}"
                      ).Result;

            string content = responseMessage.Content.ReadAsStringAsync().Result;

            Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            Pokemon result = _mapper.Map(pokemon);

            return Ok(pokemon);
        }

        //Get a multiple random pokemons

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetRandomPokemon()
        {
            List<Pokemon> pokemonList = new List<Pokemon>();

            while (pokemonList.Count < 10)
            {
                Random RandomPokemonId = new Random();

                int pokemonId = RandomPokemonId.Next(1, 898);

                HttpResponseMessage responseMessage = _httpClient.GetAsync(
                $"https://pokeapi.co/api/v2/pokemon/{pokemonId}"
           ).Result;

                string content = responseMessage.Content.ReadAsStringAsync().Result;

                Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);

                pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

                pokemonList.Add(pokemon);
            }

            return Ok(pokemonList);
        }

        //Create new pokemon trainer

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CreateNewTrainer([FromBody] Trainer trainer)
        {
            _context.Add(trainer);
            _context.SaveChanges();

            return Ok("New pokemon trainer has successfully created!");
        }

        //Capture Pokemon

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CapturePokemon([FromBody] PokemonTrainer pokemonTrainer)
        {

            HttpResponseMessage responseMessage = _httpClient.GetAsync(
                $"https://pokeapi.co/api/v2/pokemon/{pokemonTrainer.PokemonId}"
           ).Result;

            string content = responseMessage.Content.ReadAsStringAsync().Result;

            Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            _context.Add(pokemonTrainer);
            _context.Add(pokemon);
            _context.SaveChanges();

            return Ok("Pokemon has captured!");
        }

        //Get a multiple captured pokemons

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAllCaptured([FromQuery] int trainerId)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();

            IEnumerable<PokemonTrainer> pokemonTrainerList = _context.PokemonTrainer.ToList().Where(pt => pt.TrainerId == trainerId);

            foreach (PokemonTrainer pokemonTrainer in pokemonTrainerList)
            {

                HttpResponseMessage responseMessage = _httpClient.GetAsync(
               $"https://pokeapi.co/api/v2/pokemon/{pokemonTrainer.PokemonId}"
                ).Result;

                string content = responseMessage.Content.ReadAsStringAsync().Result;

                Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);

                pokemonList.Add(pokemon);
            }

            return Ok(pokemonList);
        }
    }
}