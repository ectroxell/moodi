using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;


namespace moodi.Models
{
    public class Meditation
    {
        public int ID { get; set; }
/*        public string Name { get; set; }
        public string Description { get; set; }*/
        public string Source { get; set; }
        public Meditation(string src)
        {
            Source = src;
        }
        public Meditation() { }

    }
}
