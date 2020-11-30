using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Models.Entities.Events.EventsInMatch
{
    public class Substitutions
    {
        public List<Home> home { get; set; }

        public List<Away> away { get; set; }
    }

    public class Home
    {
        public string time { get; set; }
        public string substitution { get; set; }
    }
    public class Away
    {
        public string time { get; set; }
        public string substitution { get; set; }
    }
}
