using System.Collections.Generic;
using KotasProject.Models;
using KotasProject.Models.Trainer;

namespace PokeAPI_Project.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        void NewTrainer(Trainer trainer);
        List<Pokemon> GetAllCaptured(int trainerId);
    }
}