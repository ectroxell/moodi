using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Models
{
    public class Meditation
    {
        public int ID { get; set; }
        public string SourceFile { get; set; }
        public Meditation() { }
        public Meditation(string src)
        {
            SourceFile = src;
        }
    }
}
