using System.Collections.Generic;

namespace KotasProject.Models
{
    public class Abilities
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public List<Ability> Ability { get; set; }
        public int Slot { get; set; }
    }
}