using KotasProject.Models.Trainer;
using PokeAPI_Project.Controllers.Models.Request;

namespace PokeAPI_Project.Controllers.Mapping
{
    public class TrainerMapper
    {
        public Trainer Map(TrainerRequest trainerRequest)
        {
            return new Trainer
            {
                Name = trainerRequest.Name,
                Age = trainerRequest.Age,
                Cpf = trainerRequest.Cpf
            };
        }
    }
}