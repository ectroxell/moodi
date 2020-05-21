using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using moodi.Data;
using moodi.Models;

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

            return View();
        }
        
        public IActionResult Add()
        {
            // create mood choices
            IList<Mood> moods;
            Mood happy = new Mood("Happy");
            Mood content = new Mood("Content");
            Mood stressed = new Mood("Stressed");
            Mood anxious = new Mood("Anxious");
            Mood sad = new Mood("Sad");
            Mood depressed = new Mood("Depressed");

            // add mood choices to moods list
            moods = new List<Mood>();
            moods.Add(happy);
            moods.Add(content);
            moods.Add(stressed);
            moods.Add(anxious);
            moods.Add(depressed);

            return View(moods);
        }
    }
}
