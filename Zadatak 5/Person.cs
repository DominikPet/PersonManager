using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zadatak_5
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "address")]
        public string? Address { get; set; }
        
        [Required]
        [JsonProperty(PropertyName = "age")]
        public int? Age { get; set; }

    }
}
