using SampleGraphqlApp.Data.Interface.Models.Complete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Interface.Models.Transient
{
    public class ProspectiveStudent
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string collegeId { get; set; }
    }
}
