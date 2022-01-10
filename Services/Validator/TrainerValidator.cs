using System;
using KotasProject.Models.Trainer;

namespace PokeAPI_Project.Services.Validator
{
    public class TrainerValidator
    {
        public void Validate(Trainer trainer)
        {
            if (trainer.Cpf.Length != 11)
                throw new Exception("Invalid CPF");
        }
    }
}