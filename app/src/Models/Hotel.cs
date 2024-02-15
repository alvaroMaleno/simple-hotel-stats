using System.Text.Json.Serialization;

namespace Models
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("isoCountryId")]
        public string isoCountryId {get; set; }

        [JsonPropertyName("score")]
        public string score { get; set; }
    }
}
