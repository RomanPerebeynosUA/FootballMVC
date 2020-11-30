using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.Events.EventsInMatch.LinesInMatch
{
    public class Lineup
    {
        public Home home { get; set; }

        public Away away { get; set; } 
    }

    public class Home
    {
        public Starting_lineups starting_lineups { get; set; }
        public Substitutes substitutes { get; set; }
        public Coach coach { get; set; }
        public Missing_players missing_players { get; set; }

    }
    public class Away
    {
        public Starting_lineups starting_lineups { get; set; }
        public Substitutes substitutes { get; set; }
        public Coach coach { get; set; }
        public Missing_players missing_players { get; set;}
            
    }
    public class Starting_lineups
    {
        List<LineUps> starting_lineups { get; set; }
    }
   
    public class Substitutes
    {
        List<LineUps> starting_lineups { get; set; }
    }
    public class Coach
    {
        LineUps starting_lineups { get; set; }
    }
    public class Missing_players
    {
        List<LineUps> starting_lineups { get; set; }
    }
    public class LineUps
    {
        string lineup_player { get; set; }
        string lineup_number { get; set; }
        string lineup_position { get; set; }
        string player_key { get; set; }

    }


    //    "lineup": {
    //        "home": {
    //            "starting_lineups": [
    //                {
    //                    "lineup_player": "Adarabioyo O.",
    //                    "lineup_number": "24",
    //                    "lineup_position": "3",
    //                    "player_key": "4005940793"
    //                },
    //              ...
    //            ],
    //            "substitutes": [
    //                {
    //                    "lineup_player": "Bell A.",
    //                    "lineup_number": "17",
    //                    "lineup_position": "",
    //                    "player_key": "1531290729"
    //                },
    //              .....
    //            ],
    //            "coach": [
    //                {
    //                    "lineup_player": "Mowbray T.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "2430413915"
    //                }
    //            ],
    //            "missing_players": [
    //                {
    //                    "lineup_player": "Cunningham G.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "3268203923"
    //                },
    //                {
    //"lineup_player": "Grayson J.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "2225748760"
    //                },
    //                {
    //"lineup_player": "Hart S.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "1138968531"
    //                },
    //                {
    //"lineup_player": "Williams D.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "816082123"
    //                }
    //            ]
    //        },
    //        "away": {
    //"starting_lineups": [
    //                {
    //    "lineup_player": "Benrahma S.",
    //                    "lineup_number": "10",
    //                    "lineup_position": "11",
    //                    "player_key": "666304937"
    //                },
    //                {
    //    "lineup_player": "Dalsgaard H.",
    //                    "lineup_number": "22",
    //                    "lineup_position": "2",
    //                    "player_key": "740633884"
    //                },
    //                {
    //    "lineup_player": "Henry R.",
    //                    "lineup_number": "3",
    //                    "lineup_position": "5",
    //                    "player_key": "3443158598"
    //                },
    //                {
    //    "lineup_player": "Jansson P. (C)",
    //                    "lineup_number": "18",
    //                    "lineup_position": "3",
    //                    "player_key": "2208205903"
    //                },
    //                {
    //    "lineup_player": "Jensen M.",
    //                    "lineup_number": "8",
    //                    "lineup_position": "6",
    //                    "player_key": "1715901612"
    //                },
    //                {
    //    "lineup_player": "Mokotjo K.",
    //                    "lineup_number": "12",
    //                    "lineup_position": "8",
    //                    "player_key": "3448591858"
    //                },
    //                {
    //    "lineup_player": "Norgaard C.",
    //                    "lineup_number": "6",
    //                    "lineup_position": "7",
    //                    "player_key": "2266591271"
    //                },
    //                {
    //    "lineup_player": "Pinnock E.",
    //                    "lineup_number": "5",
    //                    "lineup_position": "4",
    //                    "player_key": "3680087679"
    //                },
    //                {
    //    "lineup_player": "Raya D. (G)",
    //                    "lineup_number": "1",
    //                    "lineup_position": "1",
    //                    "player_key": "449330616"
    //                },
    //                {
    //    "lineup_player": "Watkins O.",
    //                    "lineup_number": "11",
    //                    "lineup_position": "10",
    //                    "player_key": "860730537"
    //                },
    //                {
    //    "lineup_player": "Zamburek J.",
    //                    "lineup_number": "31",
    //                    "lineup_position": "9",
    //                    "player_key": "2223355364"
    //                }
    //            ],
    //            "substitutes": [
    //                {
    //    "lineup_player": "Bech Sorensen M.",
    //                    "lineup_number": "29",
    //                    "lineup_position": "",
    //                    "player_key": "889626312"
    //                },
    //                {
    //    "lineup_player": "Daniels L. (G)",
    //                    "lineup_number": "28",
    //                    "lineup_position": "",
    //                    "player_key": "428110788"
    //                },
    //                {
    //    "lineup_player": "Da Silva J.",
    //                    "lineup_number": "14",
    //                    "lineup_position": "",
    //                    "player_key": "2560597335"
    //                },
    //                {
    //    "lineup_player": "Mbeumo B.",
    //                    "lineup_number": "19",
    //                    "lineup_position": "",
    //                    "player_key": "3508648847"
    //                },
    //                {
    //    "lineup_player": "Oksanen J.",
    //                    "lineup_number": "34",
    //                    "lineup_position": "",
    //                    "player_key": "1143420202"
    //                },
    //                {
    //    "lineup_player": "Roerslev Rasmussen M.",
    //                    "lineup_number": "35",
    //                    "lineup_position": "",
    //                    "player_key": "3352612677"
    //                },
    //                {
    //    "lineup_player": "Thompson D.",
    //                    "lineup_number": "2",
    //                    "lineup_position": "",
    //                    "player_key": "3679561210"
    //                }
    //            ],
    //            "coach": [
    //                {
    //    "lineup_player": "Frank T.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "3099306104"
    //                }
    //            ],
    //            "missing_players": [
    //                {
    //    "lineup_player": "Jeanvier J.",
    //                    "lineup_number": "-1",
    //                    "lineup_position": "",
    //                    "player_key": "2808101100"
    //                }
    //            ]
    //        }
    //    },
}
