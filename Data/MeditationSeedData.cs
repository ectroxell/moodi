using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using moodi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Data
{
    public class MeditationSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Meditations.Any())
                {
                    return;   // DB has been seeded
                }

                Meditation happy = new Meditation()
                {
                    Name = "Joy Meditation (Strengthen Happiness)",
                    Description = "Spend a few minutes rejoicing and feel that much happier.  A Joy mindfulness meditation created by Stop, Breathe & Think. ",
                    SourceFile = "/media/happy.mp3"
                };
                Meditation energized = new Meditation()
                {
                    Name = "Mindful Walking Meditation",
                    Description = "Life is a journey. Enjoy a little peace of mind on your path toward your destination.  A Mindful Walking mindfulness meditation created by Stop, Breathe & Think. ",
                    SourceFile = "/media/energized.mp3"
                };
                Meditation content = new Meditation()
                {
                    Name = "10 Minute Mindfullness Meditation | Be Present",
                    Description = "Tamara Levitt guides this 10 minute Daily Calm mindfulness meditation to powerfully restore and re-connect with the present.",
                    SourceFile = "/media/content.mp3"
                };
                Meditation stressed = new Meditation()
                {
                    Name = "3-minute Mindful Breathing Meditation (Relieve Stress)",
                    Description = "Feel more settled and calm by spending a few minutes focused on your breathing.  A 3-minute Mindful Breathing mindfulness meditation created by Stop, Breathe & Think. ",
                    SourceFile = "/media/stressed.mp3"
                };
                Meditation anxious = new Meditation()
                {
                    Name = "Meditation for Working with Difficulties",
                    Description = null,
                    SourceFile = "/media/anxious.mp3"
                };
                Meditation sad = new Meditation()
                {
                    Name = "Loving Kindness Meditation",
                    Description = null,
                    SourceFile = "/media/sad.mp3"
                };
                Meditation depressed = new Meditation()
                {
                    Name = "Positive Thinking Meditation: Endorphin Meditation with Positive Affirmations",
                    Description = "Guided Positive Thinking Meditation by Linda Hall, meditation teacher and personal development coach.",
                    SourceFile = "/media/depressed.mp3"
                };

                //add to db and save changes

                context.Meditations.AddRange(happy, energized, content, stressed, anxious, sad, depressed);
                context.SaveChanges();
            }
        }
    }
}