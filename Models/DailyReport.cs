﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Models
{
    public class DailyReport
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public Mood Mood { get; set; }
        public int MoodIntensity { get; set; }
        public Journal Journal { get; set; }
    }
}