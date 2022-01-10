using System.Collections.Generic;
using PokeAPI_Project.Models.Base;

namespace KotasProject.Models.Trainer
{
    public class Trainer : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}