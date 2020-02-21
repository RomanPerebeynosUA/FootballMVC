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
      [Key]
      public int Id { get; set; }

      [JsonPropertyName("team_name")]
      [Display(Name = "Назва")]
      public string Team_Name { get; set; }

      [JsonPropertyName("overall_league_position")]
      [Display(Name = "Позиція в таблиці")]
      public string LeaguePosition { get; set; }

      [JsonPropertyName("overall_league_payed")]
      [Display(Name = "Кількість зіграних матчів")]
      public string League_payed { get; set; }

      [JsonPropertyName("overall_league_W")]
      [Display(Name = "Кількість виграних матчів")]
      public string League_W { get; set; }

      [JsonPropertyName("overall_league_D")]
      [Display(Name = "Кількість нічіїх")]
      public string League_D { get; set; }

      [JsonPropertyName("overall_league_L")]
      [Display(Name = "Кількість програних матчів")]
      public string League_L { get; set; }

      [JsonPropertyName("overall_league_PTS")]
      [Display(Name = "Кількість очків")]
      public string League_PTS { get; set; }

        public Competition Competition { get; set; }

        [JsonPropertyName("league_id")]
        public string Competition_Id { get; set; }

        public Team Team { get; set; }

        [JsonPropertyName("team_id")]
        public string Team_id { get; set; }
    }
}
