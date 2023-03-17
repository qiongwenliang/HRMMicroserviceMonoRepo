using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Model
{
    public class CanidateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string? ResumeUrl { get; set; }
        public string FileName { get; set; }
    }
}
