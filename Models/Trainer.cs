using System.Collections.Generic;

namespace KotasProject.Models.Trainer
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<Pokemon> Pokemons { get; set; }
    }
}