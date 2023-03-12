using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.ModelRef
{
    public class CandidateModel
    {
        //its purpose is to transfer the data, but it will not have any entity related to this class
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string? ResumeUrl { get; set; }
    }
}
