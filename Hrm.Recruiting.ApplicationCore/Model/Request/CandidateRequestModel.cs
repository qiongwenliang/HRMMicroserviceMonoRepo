using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Model.Request
{
    public class CandidateRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Mobile is required"), DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string? ResumeUrl { get; set; }
        public string FileName { get; set; }
    }
}
