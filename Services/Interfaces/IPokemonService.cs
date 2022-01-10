using System.Collections.Generic;
using KotasProject.Models;
using PokeAPI_Project.Controllers.Models.Response;

namespace PokeAPI_Project.Services.Interfaces
{
    public interface IPokemonService
    {
        PokemonResponse GetPokemon(int? id, string name);

        List<PokemonResponse> GetRandomPokemon();
    }
}