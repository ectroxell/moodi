using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace moodi.Models
{
    public class Mood
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public Mood(string name, string src)
        {
            Name = name;
            Source = src;
        }
        public Mood ()
        {
        }
    }
}
