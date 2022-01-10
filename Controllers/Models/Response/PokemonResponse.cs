using System.Collections.Generic;
using KotasProject.Models;

namespace PokeAPI_Project.Controllers.Models.Response
{
    public class PokemonResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Sprites Sprites { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public List<Abilities> Abilities { get; set; }

    }
}