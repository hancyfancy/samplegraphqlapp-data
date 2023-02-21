using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Interface.Models
{
    public class Student
    {
        public string id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public College college { get; set; }
    }
}
