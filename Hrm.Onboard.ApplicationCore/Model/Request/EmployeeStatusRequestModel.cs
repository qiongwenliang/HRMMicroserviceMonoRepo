using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.ApplicationCore.Model.Request
{
    public class EmployeeStatusRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ABBR { get; set; }
    }
}
