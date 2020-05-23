using Microsoft.AspNetCore.Mvc.Rendering;
using moodi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.ViewModels
{
    public class AddDailyReportViewModel
    {
        public DateTime Date { get; set; }
        [Required]
        [Display(Name ="Mood")]
        public int MoodID { get; set; }
        public List<SelectListItem> Moods { get; set; }
        public AddDailyReportViewModel(IEnumerable<Mood> moods)
        {
            Moods = new List<SelectListItem>();

            foreach (Mood mood in moods)
            {
                Moods.Add(new SelectListItem
                {
                    Value = mood.ID.ToString(),
                    Text = mood.Name
                });
            }
        }
        public AddDailyReportViewModel()
        {
        }
    }
}
