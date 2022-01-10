using System.Collections.Generic;
using System.Linq;
using KotasProject.Data;
using KotasProject.Models;
using KotasProject.Models.Trainer;
using PokeAPI_Project.Controllers.ExternalRequest;
using PokeAPI_Project.Repositories.Interfaces;

namespace PokeAPI_Project.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DataContext _context;

        public TrainerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Pokemon> GetAllCaptured(int trainerId)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            Pokemon pokemon = new Pokemon();

            IEnumerable<PokemonTrainer> pokemonTrainerList = _context.PokemonTrainer.ToList().Where(pt => pt.TrainerId == trainerId);

            foreach (PokemonTrainer pokemonTrainer in pokemonTrainerList)
            {
                pokemon = PokeAPI.GetPokemonById(pokemonTrainer.PokemonId);

                pokemon.TrainerId = pokemonTrainer.TrainerId;

                pokemonList.Add(pokemon);
            }

            return pokemonList;

        }
        public void NewTrainer(Trainer trainer)
        {
            _context.Add(trainer);
            _context.SaveChanges();
        }
    }
}