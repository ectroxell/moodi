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
        public Mood Mood { get; set; }
        public string JournalEntry { get; set; }
    }
}
