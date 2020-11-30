using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.Events.EventsInMatch
{
    public class Goalscorer
    {
        public string time { get; set; }
        public string home_scorer { get; set; }
        public string home_scorer_id { get; set; }
        public string home_assist { get; set; }
        public string home_assist_id { get; set; }
        public string score { get; set; }
        public string away_scorer { get; set; }
        public string away_scorer_id { get; set; }
        public string away_assist { get; set; }
        public string away_assist_id { get; set; }
        public string info { get; set; }




        // Example
        //       "goalscorer": [
        //    {
        //        "time": "11",
        //        "home_scorer": "Dack B.",
        //        "home_scorer_id": "",
        //        "home_assist": "",
        //        "home_assist_id": "",
        //        "score": "1 - 0",
        //        "away_scorer": "",
        //        "away_scorer_id": "",
        //        "away_assist": "",
        //        "away_assist_id": "",
        //        "info": ""
        //    }
        //],
    }
}
