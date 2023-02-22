using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Interface.Models.Transient
{
    public class ExistingStudent
    {
        public virtual string firstName { get; set; }

        public virtual string lastName { get; set; }

        public virtual string email { get; set; }

        public virtual string collegeId { get; set; }
    }
}
