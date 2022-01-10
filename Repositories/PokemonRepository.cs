using KotasProject.Data;
using KotasProject.Models;
using PokeAPI_Project.Repositories.Interfaces;

namespace PokeAPI_Project.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public void CapturePokemon(PokemonTrainer pokemonTrainer, Pokemon pokemon)
        {
            _context.Add(pokemonTrainer);
            _context.Add(pokemon);
            _context.SaveChanges();
        }
    }
}