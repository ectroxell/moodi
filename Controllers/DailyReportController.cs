using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moodi.Data;
using moodi.Models;
using moodi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //view details for a specific report
        public IActionResult Detail(int id)
        {
            var dailyReport = context.DailyReports.Where(c => c.ID == id).Include(c => c.Mood).Include(c => c.Journal).Single();
            return View(dailyReport);
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

                //redirect user to meditation page
                return Redirect($"../Meditation");
            }
            //return user to form if invalid
            return View(addDailyReportViewModel);
        }
    }
}