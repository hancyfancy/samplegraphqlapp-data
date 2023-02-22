using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Interface.Models.Complete
{
    public class College
    {
        public string id { get; set; }

        public string name { get; set; }

        public string location { get; set; }

        public double rating { get; set; }

        public List<Book> books { get; set; }

        public List<Student> students { get; set; }
    }
}
