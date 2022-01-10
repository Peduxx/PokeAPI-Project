using System;
using System.Collections.Generic;
using KotasProject.Controllers.Utils;
using KotasProject.Models;
using PokeAPI_Project.Controllers.ExternalRequest;
using PokeAPI_Project.Controllers.Models.Response;
using PokeAPI_Project.Repositories.Interfaces;
using PokeAPI_Project.Services.Interfaces;
using PokeAPI_Project.Services.Mapping;

namespace PokeAPI_Project.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly PokemonMapper _mapper;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = new PokemonMapper();
        }

        public PokemonResponse GetPokemon(int? id, string name)
        {
            Pokemon pokemon = new Pokemon();

            if (id == null)
                pokemon = PokeAPI.GetPokemonByName(name);

            if (String.IsNullOrEmpty(name))
                pokemon = PokeAPI.GetPokemonById(id);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            PokemonResponse response = _mapper.Map(pokemon);

            return response;
        }

        public List<PokemonResponse> GetRandomPokemon()
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

            return pokemonList;
        }

        public void CapturePokemon(PokemonTrainer pokemonTrainer)
        {
            Pokemon pokemon = new Pokemon();

            pokemon = PokeAPI.GetPokemonById(pokemonTrainer.PokemonId);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            pokemon.TrainerId = pokemonTrainer.TrainerId;

            _pokemonRepository.CapturePokemon(pokemonTrainer, pokemon);
        }
    }
}