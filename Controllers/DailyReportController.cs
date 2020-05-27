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

            // create mood choices
            Mood happy = new Mood("Happy");
            Mood content = new Mood("Content");
            Mood stressed = new Mood("Stressed");
            Mood anxious = new Mood("Anxious");
            Mood sad = new Mood("Sad");
            Mood depressed = new Mood("Depressed");

            // add mood choices to dbcontext

            context.Moods.Add(happy);
            context.Moods.Add(content);
            context.Moods.Add(stressed);
            context.Moods.Add(anxious);
            context.Moods.Add(sad);
            context.Moods.Add(depressed);

            context.SaveChanges();

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

                return Redirect("/DailyReport");
            }
            
            //return user to add page if view model is not valid
            return View(addDailyReportViewModel);
        }
    }
}
