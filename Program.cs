using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Lab5.Models;

namespace Lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<Models.ToWatchContext>();
                SeedDB(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void SeedDB(Models.ToWatchContext context)
        {
            var moviesItemList = context.ToWatchItems.ToList();
            if (moviesItemList.Count > 0) return;

            var movies = new List<ToWatchItem>();
            movies.Add(new ToWatchItem
            {
                Id = 10,
                Name = "The Shawshank Redemption",
                IsWatched = true,
                Rating = 876,
                Comments = "The Shawshank Redemption is a 1994 American drama film written and directed by Frank Darabont, based on the 1982 Stephen King novella Rita Hayworth",
            });

            movies.Add(new ToWatchItem
            {
                Id = 20,
                Name = "Intouchables",
                IsWatched = true,
                Rating = 862,
                Comments = "The Intouchables also known as Untouchable in the UK, is a French buddy comedy-drama film directed by Olivier Nakache & Éric Toledano.",
            });

            movies.Add(new ToWatchItem
            {
                Id = 30,
                Name = "The Green Mile ",
                IsWatched = true,
                Rating = 860,
                Comments = "The Green Mile is a 1999 American fantasy drama film written and directed by Frank Darabont and based on Stephen King's 1996 novel of the same name.",
            });
            movies.Add(new ToWatchItem
            {
                Id = 40,
                Name = "The Godfather ",
                IsWatched = true,
                Rating = 859,
                Comments = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his ... The Godfather follows Vito Corleone, Don of the Corleone ...",
            });


            context.AddRange(movies);
            context.SaveChanges();

        }
    }
}
