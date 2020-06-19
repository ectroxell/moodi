using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public MeditationController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            // get most recent daily report
            IList<DailyReport> dailyReports = context.DailyReports.Include(c => c.Mood).ToList();
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