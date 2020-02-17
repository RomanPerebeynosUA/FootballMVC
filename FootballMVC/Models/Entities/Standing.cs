using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities
{
    public class Standing
    {
       
        public  Competition Competition { get; set; }

        [JsonPropertyName("league_id")]
        public  string Competition_Id { get; set; }

        public Team Team { get; set; }

        [JsonPropertyName("team_id")]
        public string Team_id { get; set; }

      [JsonPropertyName("overall_league_position")]
      [Display(Name = "Позиція в таблиці")]
      public string overall_league_position { get; set; }

      [JsonPropertyName("overall_league_payed")]
      [Display(Name = "Кількість зіграних матчів")]
      public string overall_league_payed { get; set; }

      [JsonPropertyName("overall_league_W")]
      [Display(Name = "Кількість виграних матчів")]
      public string overall_league_W { get; set; }

      [JsonPropertyName("overall_league_D")]
      [Display(Name = "Кількість нічіїх")]
      public string overall_league_D { get; set; }

      [JsonPropertyName("overall_league_L")]
      [Display(Name = "Кількість програних матчів")]
      public string overall_league_L { get; set; }

      [JsonPropertyName("overall_league_PTS")]
      [Display(Name = "Кількість очків")]
      public string overall_league_PTS { get; set; }
    }
}
