using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Wef.Movies.API.Domain;

namespace Wef.Movies.API.Data
{
    public class Seeder
    {
        public async Task SeedData(DataContext context)
        {
            // Actors

            context.Actors.Add(new Actor
            {
                ActorId = 1,
                FirstName = "Kristen",
                LastName = "Wiig"
            });

            context.Actors.Add(new Actor
            {
                ActorId = 2,
                FirstName = "Maya",
                LastName = "Rudolph"
            });

            context.Actors.Add(new Actor
            {
                ActorId = 3,
                FirstName = "Rebel",
                LastName = "Wilson"
            });

            context.Actors.Add(new Actor
            {
                ActorId = 4,
                FirstName = "Vince",
                LastName = "Vaughn"
            });

            context.Actors.Add(new Actor
            {
                ActorId = 5,
                FirstName = "Owen",
                LastName = "Wilson"
            });

            await context.SaveChangesAsync();

            // Movies

            var actorsOne = context.Actors.Where(a => a.ActorId == 1 || a.ActorId == 2 || a.ActorId == 3).ToList();

            var bridesmaids = new Movie
            {
                MovieId = 1,
                Title = "Bridesmaids",
                Actors = actorsOne
            };

            ////var newClown = new Clown();


            //context.Entry(bridesmaids).State = EntityState.Unchanged;

            ////db.Entry(car).State = EntityState.Unchanged;

            //bridesmaids.Actors.AddRange(actorsOne);

            //// newClown.Cars.Add(car);

            context.Set<Movie>().Add(bridesmaids);
                
            ////db.Set<Clown>().Add(newClown);
            ////db.SaveChanges();

            await context.SaveChangesAsync();
        }
    }
}
