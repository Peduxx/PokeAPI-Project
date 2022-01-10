using System.Text.Json.Serialization;

namespace KotasProject.Models
{
    public class Sprites
    {
        [JsonPropertyName("Base64Sprite")]
        public string Front_Default { get; set; }
    }
}