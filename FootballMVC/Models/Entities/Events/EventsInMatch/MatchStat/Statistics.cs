using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.Events.EventsInMatch.MatchStat
{
    public class Statistics
    {
        public string type { get; set; }
        public string home { get; set; }
        public string away { get; set; }
    }
}
