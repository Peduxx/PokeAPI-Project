using System.Collections.Generic;
using KotasProject.Models;
using KotasProject.Models.Trainer;

namespace PokeAPI_Project.Services.Interfaces
{
    public interface ITrainerService
    {
        void NewTrainer(Trainer trainer);

        void CapturePokemon(PokemonTrainer pokemonTrainer);

        List<Pokemon> GetAllCaptured(int trainerId);
    }
}