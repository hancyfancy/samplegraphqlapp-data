using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Data.Interface.Models.Transient
{
    public class IdentifiableExistingStudent
    {
        public string id { get; set; }

        public ExistingStudent student { get; set; }
    }
}
