using System.ComponentModel.DataAnnotations;

namespace PokeAPI_Project.Controllers.Models.Request
{
    public class TrainerRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}