using System.ComponentModel.DataAnnotations.Schema;

namespace KotasProject.Models
{
    public class Abilities
    {
        [NotMapped]
        public Ability Ability { get; set; }
        public int Slot { get; set; }
    }
}