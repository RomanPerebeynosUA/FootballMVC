using FootballMVC.Models.Entities.Events.EventsInMatch;
using FootballMVC.Models.Entities.Events.EventsInMatch.LinesInMatch;
using FootballMVC.Models.Entities.Events.EventsInMatch.MatchStat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.Events
{
    public class Event
    {
        [JsonPropertyName("match_id")]
        public string match_id { get; set; }
        [JsonPropertyName("country_id")]
        public string country_id { get; set; }
        [JsonPropertyName("country_name")]
        public string country_name { get; set; }
        [JsonPropertyName("league_id")]
        public  string league_id { get; set; }
        [JsonPropertyName("league_name")]
        public string league_name { get; set; }
        [JsonPropertyName("match_date")]
        public string match_date { get; set; }
        [JsonPropertyName("match_status")]
        public string match_status { get; set; }
        [JsonPropertyName("match_time")]
        public string match_time { get; set; }
        [JsonPropertyName("match_hometeam_id")]
        public string match_hometeam_id { get; set; }
        [JsonPropertyName("match_hometeam_name")]
        public string match_hometeam_name { get; set; }
        [JsonPropertyName("match_hometeam_score")]
        public string match_hometeam_score { get; set; }
        [JsonPropertyName("match_awayteam_name")]
        public string match_awayteam_name { get; set; }
        [JsonPropertyName("match_awayteam_id")]
        public string match_awayteam_id { get; set; }
        [JsonPropertyName("match_awayteam_score")]
        public string match_awayteam_score { get; set; }
        [JsonPropertyName("match_hometeam_halftime_score")]
        public string match_hometeam_halftime_score { get; set; }
        [JsonPropertyName("match_awayteam_halftime_score")]
        public string match_awayteam_halftime_score { get; set; }
        [JsonPropertyName("match_hometeam_extra_score")]
        public string match_hometeam_extra_score { get; set; }
        [JsonPropertyName("match_awayteam_extra_score")]
        public string match_awayteam_extra_score { get; set; }
        [JsonPropertyName("match_hometeam_penalty_score")]
        public string match_hometeam_penalty_score { get; set; }
        [JsonPropertyName("match_awayteam_penalty_score")]
        public string match_awayteam_penalty_score { get; set; }
        [JsonPropertyName("match_hometeam_ft_score")]
        public string match_hometeam_ft_score { get; set; }
        [JsonPropertyName("match_awayteam_ft_score")]
        public string match_awayteam_ft_score { get; set; }
        [JsonPropertyName("match_hometeam_system")]
        public string match_hometeam_system { get; set; }
        [JsonPropertyName("match_awayteam_system")]
        public string match_awayteam_system { get; set; }
        [JsonPropertyName("match_live")]
        public string match_live { get; set; }
        [JsonPropertyName("match_round")]
        public string match_round { get; set; }
        [JsonPropertyName("match_stadium")]
        public string match_stadium { get; set; }
        [JsonPropertyName("match_referee")]
        public string match_referee { get; set; }
        [JsonPropertyName("team_home_badge")]
        public string team_home_badge { get; set; }
        [JsonPropertyName("team_away_badge")]
        public string team_away_badge { get; set; }
        [JsonPropertyName("league_logo")]
        public string league_logo { get; set; }
        [JsonPropertyName("country_logo")]
        public string country_logo { get; set; }
        public List<Goalscorer> goalscorer { get; set; }
        public List<Cards> cards { get; set; }
        public Substitutions substitutions { get; set; }
        public Lineup lineup { get; set; }
        public List<Statistics> statistics { get; set; }


    }
}
