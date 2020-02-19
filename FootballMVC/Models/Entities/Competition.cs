using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities
{
    public class Competition
    {
        [JsonPropertyName("league_id")]
        [Key]
        public string Id { get; set; }

        [JsonPropertyName("league_name")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [JsonPropertyName("country_id")]
        public string CountryId { get; set; }
        public Country Country { get; set; }


    }
}
