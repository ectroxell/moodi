using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using moodi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Data
{
    public class MoodSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any moods.
                if (context.Moods.Any())
                {
                    return;   // DB has been seeded
                }

                context.Moods.Add(new Mood() { Name = "Happy" });
                context.Moods.Add(new Mood() { Name = "Content" });
                context.Moods.Add(new Mood() { Name = "Energized" });
                context.Moods.Add(new Mood() { Name = "Stressed" });
                context.Moods.Add(new Mood() { Name = "Anxious" });
                context.Moods.Add(new Mood() { Name = "Sad" });
                context.Moods.Add(new Mood() { Name = "Depressed" });
                context.SaveChanges();
            }
        }
    }
}