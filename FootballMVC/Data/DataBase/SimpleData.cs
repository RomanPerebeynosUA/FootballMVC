using FootballMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballMVC.Data.DataBase
{
    public static class SimpleData
    {
            public static void Initialize(AppDBContext context)
            {
            if (!context.Teams.Any())
            {

                context.Teams.AddRange(
                    new Team
                    {
                        Id = "343",
                        Name = "VinnitsaFoot"
                    },
                       new Team
                       {
                           Id = "344",
                           Name = "VinnitsaGrand"
                       }
                );
                context.SaveChanges();
            }
            if (!context.Players.Any())
                {

                context.Players.AddRange(
                    new Player
                    {
                        Id = 1,
                        Name = "Roman Perebeynos",
                        Age = "20",
                        TeamId = "344"
                    },
                    new Player
                    {
                        Id = 2,
                        Name = "Petro Perebeynos",
                        Age = "20",
                        TeamId = "343"
                    });
                    context.SaveChanges();
                }
          
        } 
    }
}
