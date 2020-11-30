using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMVC.Data.ApiData.Interfaces;
using FootballMVC.Data.ApiData.Repositories;
using FootballMVC.Data.ApiData.Repositories.Events;
using FootballMVC.Data.ApiData.Repositories.PlayersInTeam;
using FootballMVC.Data.BdData.Interfaces;
using FootballMVC.Data.BdData.Repositories;
using FootballMVC.Data.DataBase;
using FootballMVC.Models.Entities;
using FootballMVC.Models.Entities.Events;
using FootballMVC.Models.Entities.PlayersInTeam;
using FootballMVC.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballMVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
            services.AddDbContext<AppDBContext>(x => x.UseSqlServer(Config.ConnectionString));

            
            services.AddTransient<IRepositoryApi<Country, string>, CountryApi>();
            services.AddTransient<IRepositoryApi<Competition, string>, CompetitionApi>();
            services.AddTransient<IRepositoryApi<Team, string>, TeamApi>();
            services.AddTransient<IRepositoryApi<Standing, int>, StandingApi>();
            services.AddTransient<IRepositoryApi<Player, long>, PlayerApi>();
            services.AddTransient<IRepositoryApi<TeamWithPlayers, string>, TeamWithPlayersApi>();
            services.AddTransient<IRepositoryApi<Event, string>, EventApi>();
            services.AddTransient<DataManager>();

            services.AddTransient<IRepositoryBd<Country, string>, CountryRepositoryBd>();
            services.AddTransient<IRepositoryBd<Competition, string>, CompetitionRepositoryBd>();
            services.AddTransient<IRepositoryBd<Team, string>, TeamRepositoryBd>();
            services.AddTransient<IRepositoryBd<Standing, int>, StandingRepositoryBd>();
            services.AddTransient<IRepositoryBd<Player, long>, PlayerRepositoryBd>();
            services.AddTransient<DataManagerBd>();
            services.AddControllersWithViews();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                SimpleData.Initialize(context);
            }


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
