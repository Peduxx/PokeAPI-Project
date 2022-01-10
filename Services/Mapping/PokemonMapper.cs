using KotasProject.Models;
using PokeAPI_Project.Controllers.Models.Response;

namespace PokeAPI_Project.Services.Mapping
{
    public class PokemonMapper
    {
        public PokemonResponse Map(Pokemon pokemon)
        {
            return new PokemonResponse
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Sprites = pokemon.Sprites,
                Height = pokemon.Height,
                Weight = pokemon.Weight,
                Abilities = pokemon.Abilities
            };
        }
    }
}