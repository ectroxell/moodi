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
        [Display(Name = "Mood")]
        public int MoodID { get; set; }

        public List<SelectListItem> Moods { get; set; }

        [Required]
        [Display(Name = "Mood Intensity")]
        public int MoodIntensity { get; set; }

        public List<SelectListItem> MoodIntensityScale { get; set; }

        [Display(Name = "Journal Entry")]
        public string JournalText { get; set; }

        public AddDailyReportViewModel(IEnumerable<Mood> moods, IEnumerable<int> intensityScale)
        {
            Moods = new List<SelectListItem>();
            MoodIntensityScale = new List<SelectListItem>();

            foreach (Mood mood in moods)
            {
                Moods.Add(new SelectListItem
                {
                    Value = mood.ID.ToString(),
                    Text = mood.Name
                });
            }

            foreach (int num in intensityScale)
            {
                MoodIntensityScale.Add(new SelectListItem
                {
                    Value = num.ToString(),
                    Text = num.ToString()
                });
            }
        }

        public AddDailyReportViewModel()
        {
        }
    }
}