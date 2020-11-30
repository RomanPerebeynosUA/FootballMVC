using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.Events.EventsInMatch
{
    public class Cards
    {
        public string time { get; set; }
        public string home_fault { get; set; }
        public string card { get; set; }
        public string away_fault { get; set; }
        public string info { get; set; }


        // Example 
        //"cards": [
        //    {
        //        "time": "44",
        //        "home_fault": "Dack B.",
        //        "card": "yellow card",
        //        "away_fault": "",
        //        "info": ""
        //    },
        //    {
        //        "time": "79",
        //        "home_fault": "Evans C.",
        //        "card": "yellow card",
        //        "away_fault": "",
        //        "info": ""
        //    },
        //    {
        //        "time": "90+1",
        //        "home_fault": "",
        //        "card": "yellow card",
        //        "away_fault": "Roerslev Rasmussen M.",
        //        "info": ""
        //    }
        //],
    }
}
