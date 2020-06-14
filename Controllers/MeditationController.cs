using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moodi.Data;
using moodi.ViewModels;

namespace moodi.Controllers
{
    public class MeditationController : Controller
    {
        private ApplicationDbContext context;
        //private UserManager<User> _userManager;
        public MeditationController(ApplicationDbContext dbContext)
        {
            context = dbContext;

        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
