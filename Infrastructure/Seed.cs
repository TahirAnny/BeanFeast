using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            //check if there any activites in DB
            if (context.Activities.Any()) return;

            //if there is no activities in DB then create new
            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Intro to Next.JS",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "Knowledge Sharing",
                    City = "Dhaka",
                    Venue = "JS Building",
                },
                new Activity
                {
                    Title = "JS Meetup",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Activity 1 month ago",
                    Category = "Knowledge Sharing",
                    City = "Dhaka",
                    Venue = "Online",
                },
                new Activity
                {
                    Title = "Women In AWS",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Activity 1 month in future",
                    Category = "Technical",
                    City = "NewYork",
                    Venue = "Virtual",
                },
                new Activity
                {
                    Title = "Azure Fundamental Day",
                    Date = DateTime.Now.AddMonths(2),
                    Description = "Activity 2 months in future",
                    Category = "Technical",
                    City = "Hydrabad",
                    Venue = "IP Park",
                },
                new Activity
                {
                    Title = "Super Hero Comicon",
                    Date = DateTime.Now.AddMonths(3),
                    Description = "Activity 3 months in future",
                    Category = "Film Festival",
                    City = "London",
                    Venue = "Cinema",
                },
                new Activity
                {
                    Title = "AWS She Builds Day",
                    Date = DateTime.Now.AddMonths(4),
                    Description = "Activity 4 months in future",
                    Category = "Technical",
                    City = "Silicon Valley",
                    Venue = "Virtual",
                },
                new Activity
                {
                    Title = "Filmfare Music Award",
                    Date = DateTime.Now.AddMonths(5),
                    Description = "Activity 5 months in future",
                    Category = "Music",
                    City = "Mumbai",
                    Venue = "Somewhere in Mumbai",
                },
                new Activity
                {
                    Title = "Bali Tour",
                    Date = DateTime.Now.AddMonths(7),
                    Description = "Activity 2 months ago",
                    Category = "travel",
                    City = "Maldives",
                    Venue = "Bali",
                },
                new Activity
                {
                    Title = "Black Widow Launch Party",
                    Date = DateTime.Now.AddMonths(8),
                    Description = "Activity 8 months in future",
                    Category = "film",
                    City = "Paris",
                    Venue = "Cinema",
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}