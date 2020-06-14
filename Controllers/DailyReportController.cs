using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        //private UserManager<User> _userManager;
        public DailyReportController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //get existing daily reports from database
            
            IList<DailyReport> dailyReports = context.DailyReports.Include(c => c.Mood).Include(c => c.Journal).ToList();
                

            return View(dailyReports);
        }
        
        public IActionResult Add()
        {
            
            if (!context.Moods.Any())
            {
                // create default mood choices
                context.Moods.Add(new Mood("Happy"));
                context.Moods.Add(new Mood("Content"));
                context.Moods.Add(new Mood("Energized"));
                context.Moods.Add(new Mood("Stressed"));
                context.Moods.Add(new Mood("Anxious"));
                context.Moods.Add(new Mood("Sad"));
                context.Moods.Add(new Mood("Depressed"));
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
                Journal newDailyReportJournal = new Journal(addDailyReportViewModel.JournalText);
                DailyReport newDailyReport = new DailyReport
                {
                    Date = DateTime.Now,
                    Mood = newDailyReportMood,
                    Journal = newDailyReportJournal
                };

                //add daily report to existing reports
                context.Journals.Add(newDailyReportJournal);
                context.DailyReports.Add(newDailyReport);
                context.SaveChanges();

                return View("PlayMeditation");
            }
            
            //return user to add page if view model is not valid
            return View(addDailyReportViewModel);
        }

        public IActionResult PlayMeditation()
        {
            
            return View();
        }

        public IActionResult ViewDetails()
        {
            return View();
        }
    }
}
