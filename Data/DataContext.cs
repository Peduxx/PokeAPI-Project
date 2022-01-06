using KotasProject.Models;
using KotasProject.Models.Trainer;
using Microsoft.EntityFrameworkCore;

namespace KotasProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<PokemonTrainer> PokemonTrainer { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Sprites> Sprites { get; set; }
        public DbSet<Abilities> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PokemonTrainer>().HasKey(PT => new { PT.PokemonId, PT.TrainerId });
        }

    }
}