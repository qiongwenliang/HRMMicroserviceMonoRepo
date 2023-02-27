using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.Entity
{
    public class Interviewer
    {
        public int Id { get; set; }
        [Required, Column(TypeName ="nvarchar(128)")]
        public string FirstName { get; set; }
        [Required, Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
    }
}
