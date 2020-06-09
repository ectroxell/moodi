using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using moodi.Data;
using moodi.Models;
using moodi.ViewModels;


namespace moodi.Controllers
{
    public class DailyReportController : Controller
    {
        private ApplicationDbContext context;
        public DailyReportController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //get existing daily reports from database
            IList<DailyReport> dailyReports = context.DailyReports.Include(c => c.Mood).ToList();

            return View(dailyReports);
        }
        
        public IActionResult Add()
        {
            
            if (!context.Moods.Any())
            {
                // create default mood choices
                context.Moods.Add(new Mood() { 
                    Name = "Happy", 
                    Meditation = new Meditation()
                });
                context.Moods.Add(new Mood() { 
                    Name = "Content",
                    Meditation = new Meditation()
                });
                context.Moods.Add(new Mood() { 
                    Name = "Energized", 
                    Meditation = new Meditation()
                });
                context.Moods.Add(new Mood() { 
                    Name = "Stressed",
                    Meditation = new Meditation()
                });
                context.Moods.Add(new Mood() { 
                    Name = "Anxious",
                    Meditation = new Meditation()
                });
                context.Moods.Add(new Mood() { 
                    Name = "Sad",
                    Meditation = new Meditation("Data/MeditationData/05_Loving_Kindness_Meditation.mp3")
                });
                context.Moods.Add(new Mood() { 
                    Name = "Depressed",
                    Meditation = new Meditation()    
                });
                context.SaveChanges();
            }


            //create view model
            IList<Mood> moods = context.Moods.ToList();
            AddDailyReportViewModel addDailyReportViewModel = new AddDailyReportViewModel(moods);

            return View(addDailyReportViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddDailyReportViewModel addDailyReportViewModel)
        {
            //create new daily report if view model is valid
            if (ModelState.IsValid)
            {
                Mood newDailyReportMood = context.Moods.Single(c => c.ID == addDailyReportViewModel.MoodID);
                DailyReport newDailyReport = new DailyReport
                {
                    Date = DateTime.Now,
                    Mood = newDailyReportMood
                };

                //add daily report to existing reports
                context.DailyReports.Add(newDailyReport);
                context.SaveChanges();

                return Redirect("/Meditation");
            }
            
            //return user to add page if view model is not valid
            return View(addDailyReportViewModel);
        }
    }
}
