using System.Net.Http;
using KotasProject.Models;

namespace PokeAPI_Project.Controllers.ExternalRequest
{
    public static class PokeAPI
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        public static Pokemon GetPokemonById(int? id)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync(
                           $"https://pokeapi.co/api/v2/pokemon/{id}"
                      ).Result;

            string content = responseMessage.Content.ReadAsStringAsync().Result;

            Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);

            return pokemon;
        }

        public static Pokemon GetPokemonByName(string name)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync(
                           $"https://pokeapi.co/api/v2/pokemon/{name}"
                      ).Result;

            string content = responseMessage.Content.ReadAsStringAsync().Result;

            Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(content);

            return pokemon;
        }

    }
}