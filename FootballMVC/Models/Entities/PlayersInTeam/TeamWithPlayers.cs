using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.PlayersInTeam
{
    public class TeamWithPlayers
    {
        [JsonPropertyName("team_key")]
        [Key]
        public string Id { get; set; }

        [JsonPropertyName("team_name")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }
    }
}
