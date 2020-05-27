using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using moodi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Data
{
    public static class MoodSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Moods.Any())
            {
                // create default mood choices
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
