using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities
{
    public class Country
    {
        [JsonPropertyName("country_id")]
        [Key]
        public string Id { get; set; }

        [Display(Name = "Назва країни")]
        [JsonPropertyName("country_name")]
        public string Name { get; set; }

        public List<Competition> Competitions { get; set; }

    }
}
