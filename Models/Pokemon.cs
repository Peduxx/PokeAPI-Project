using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PokeAPI_Project.Models.Base;

namespace KotasProject.Models
{
    public class Pokemon : BaseEntity
    {
        public string Name { get; set; }

        [NotMapped]
        public Sprites Sprites { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        [NotMapped]
        public List<Abilities> Abilities { get; set; }

        public int TrainerId { get; set; }
    }
}