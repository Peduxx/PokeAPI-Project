using KotasProject.Models;

namespace PokeAPI_Project.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        void CapturePokemon(PokemonTrainer pokemonTrainer, Pokemon pokemon);
    }
}