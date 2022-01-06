using KotasProject.Models;

namespace KotasProject.Controllers.Mapping
{
    public class PokemonMapper
    {
        public Pokemon Map(Pokemon pokemon)
        {
            return new Pokemon
            {
                Name = pokemon.Name,
                Sprites = pokemon.Sprites,
                Height = pokemon.Height,
                Weight = pokemon.Weight,
                Abilities = pokemon.Abilities
            };
        }
    }
}