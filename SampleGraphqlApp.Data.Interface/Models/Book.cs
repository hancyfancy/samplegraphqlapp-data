﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Interface.Models
{
    public class Book
    {
        public string id { get; set; }

        public string name { get; set; }

        public string author { get; set; }

        public List<College> colleges { get; set; }
    }
}
