using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities
{
    public class Player
    {
        [JsonPropertyName("player_key")]
        [Key]
        public long Id { get; set; }

        [JsonPropertyName("player_name")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        
        [JsonPropertyName("player_number")]
        [Display(Name = "Номер")]
        public string Number { get; set; }

        [Display(Name = "Країна")]
        [JsonPropertyName("player_country")]
        public string Country { get; set; }

        [JsonPropertyName("player_type")]
        [Display(Name = "Тип футболіста")]
        public string Type { get; set; }

        [JsonPropertyName("player_age")]
        [Display(Name = "Вік")]
        public string Age { get; set; }

        [JsonPropertyName("player_match_played")]
        [Display(Name = "Зіграно матчів")]
        public string Match_played { get; set; }

        [JsonPropertyName("player_goals")]
        [Display(Name = "Кількість голів")]
        public string Goals { get; set; }

        [JsonPropertyName("player_yellow_cards")]
        [Display(Name = "Кількість жовтих карточок")]
        public string Yellow_cards { get; set; }

        [JsonPropertyName("player_red_cards")]
        [Display(Name = "Кількість червоних карточок")]
        public string Red_cards { get; set; }
        
        [JsonPropertyName("team_key")]
        public string TeamId { get; set; }
        public Team Team { get; set; }

    }
}
