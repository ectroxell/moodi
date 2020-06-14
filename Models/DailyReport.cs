using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Models
{
    public class DailyReport
    {
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public Mood Mood { get; set; }
        public int MoodID { get; set; }
        public Journal Journal { get; set; }
        public int JournalID { get; set; }
/*        public override string ToString()
        {
            string date = Date.ToShortDateString();
            return $"{date}: {Mood.Name} || {Journal.Text}";
        }
*/
    }
}
