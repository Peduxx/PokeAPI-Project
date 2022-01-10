using System.Collections.Generic;
using KotasProject.Models;
using KotasProject.Models.Trainer;
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

        public List<Pokemon> GetAllCaptured(int trainerId)
        {
            List<Pokemon> pokemonList = _trainerRepository.GetAllCaptured(trainerId);

            return pokemonList;
        }
    }
}