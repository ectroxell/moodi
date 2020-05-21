using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using moodi.Data;
using moodi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace moodi.Controllers
{
    public class MoodController : Controller
    {
        private ApplicationDbContext context;
        public MoodController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
           // manually add default mood choices to moods list
           
            return View();
        }
        
        public IActionResult Add()
        {
            return View();
        }
    }
}
