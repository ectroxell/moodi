using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moodi.Data;
using moodi.Models;
using moodi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Controllers
{
    public class DailyReportController : Controller
    {
        private ApplicationDbContext context;

        private UserManager<AppUser> userManager;

        public DailyReportController(ApplicationDbContext dbContext, UserManager<AppUser> _userManager)
        {
            context = dbContext;
            userManager = _userManager;
        }

        // GET: /<controller>/
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //get existing user daily reports from database
            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);
            IList<DailyReport> dailyReports = context.DailyReports.Include(c => c.Mood).Include(c => c.Journal).Where(c => c.UserID == currentUser.Id).ToList();

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
            //create view model
            IList<Mood> moods = context.Moods.ToList();
            IList<int> scale = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            AddDailyReportViewModel addDailyReportViewModel = new AddDailyReportViewModel(moods, scale);

            return View(addDailyReportViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDailyReportViewModel addDailyReportViewModel)
        {
            //create new daily report if view model is valid
            if (ModelState.IsValid)
            {
                AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);
                Mood newDailyReportMood = context.Moods.Single(c => c.ID == addDailyReportViewModel.MoodID);
                Journal newDailyReportJournal = new Journal(addDailyReportViewModel.JournalText);
                DailyReport newDailyReport = new DailyReport
                {
                    UserID = currentUser.Id,
                    Date = DateTime.Now,
                    Mood = newDailyReportMood,
                    Journal = newDailyReportJournal,
                    MoodIntensity = addDailyReportViewModel.MoodIntensity
                };

                //add daily report to existing reports
                context.Journals.Add(newDailyReportJournal);
                context.DailyReports.Add(newDailyReport);
                context.SaveChanges();

                //redirect user to meditation page
                return Redirect("../Meditation");
            }
            //return user to form if invalid
            return View(addDailyReportViewModel);
        }
    }
}