using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Model.Request
{
    public class SubmissionStatusRequestModel
    {
        public int LookupCode { get; set; }
        public string Description { get; set; }
    }
}
