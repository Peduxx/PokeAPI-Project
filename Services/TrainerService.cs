using System.Collections.Generic;
using KotasProject.Controllers.Utils;
using KotasProject.Models;
using KotasProject.Models.Trainer;
using PokeAPI_Project.Controllers.ExternalRequest;
using PokeAPI_Project.Repositories.Interfaces;
using PokeAPI_Project.Services.Interfaces;
using PokeAPI_Project.Services.Validator;

namespace PokeAPI_Project.Services
{
    public class TrainerService : ITrainerService
    {

        private readonly ITrainerRepository _trainerRepository;
        private readonly TrainerValidator _validator;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
            _validator = new TrainerValidator();
        }

        public void NewTrainer(Trainer trainer)
        {
            _validator.Validate(trainer);

            _trainerRepository.NewTrainer(trainer);
        }

        public void CapturePokemon(PokemonTrainer pokemonTrainer)
        {
            Pokemon pokemon = new Pokemon();

            pokemon = PokeAPI.GetPokemonById(pokemonTrainer.PokemonId);

            pokemon.Sprites.Front_Default = StringConvert.FromStringToBase64(pokemon.Sprites.Front_Default);

            pokemon.TrainerId = pokemonTrainer.TrainerId;

            _trainerRepository.CapturePokemon(pokemonTrainer, pokemon);
        }

        public List<Pokemon> GetAllCaptured(int trainerId)
        {
            List<Pokemon> pokemonList = _trainerRepository.GetAllCaptured(trainerId);

            return pokemonList;
        }
    }
}