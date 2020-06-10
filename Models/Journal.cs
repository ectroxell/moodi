using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Models
{
    public class Journal
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Journal(string text)
        {
            Text = text;
        }
        public Journal() { }
        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
