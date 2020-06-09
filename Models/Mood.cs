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
        public Meditation Meditation { get; set; }

        public Mood(string name /*Meditation meditation*/)
        {
            Name = name;
           // Meditation = meditation;
        }
        public Mood ()
        {
        }
    }
}
