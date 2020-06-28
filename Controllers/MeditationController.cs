using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moodi.Data;
using moodi.Models;
using moodi.ViewModels;

namespace moodi.Controllers
{
    public class MeditationController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<AppUser> userManager;

        public MeditationController(ApplicationDbContext dbContext, UserManager<AppUser> _userManager)
        {
            context = dbContext;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            // get most recent daily report for current user
            AppUser currentUser = await userManager.GetUserAsync(HttpContext.User);
            IList<DailyReport> dailyReports = context.DailyReports.Include(c => c.Mood).Where(c => c.UserID == currentUser.Id).ToList();
            Mood mood = dailyReports.Last().Mood;

            // get meditation that corresponds to mood
            IList<Meditation> meditations = context.Meditations.Where(c => c.ID == mood.ID).ToList();
            Meditation meditation = meditations.Last();

            //create view model
            MeditationViewModel meditationViewModel = new MeditationViewModel(mood, meditation);

            return View(meditationViewModel);
        }
    }
}