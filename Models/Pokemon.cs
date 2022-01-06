using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KotasProject.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

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