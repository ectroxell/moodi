﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moodi.Models
{
    public class Meditation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceFile { get; set; }

        public Meditation()
        {
        }
    }
}