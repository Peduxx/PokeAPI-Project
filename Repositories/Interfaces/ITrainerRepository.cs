using System.Collections.Generic;
using KotasProject.Models;
using KotasProject.Models.Trainer;

namespace PokeAPI_Project.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        void NewTrainer(Trainer trainer);

        void CapturePokemon(PokemonTrainer pokemonTrainer, Pokemon pokemon);

        List<Pokemon> GetAllCaptured(int trainerId);
    }
}