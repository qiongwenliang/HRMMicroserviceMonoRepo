using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.ApplicationCore.Model.Request
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public int SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int EmployeeStatusId { get; set; }
        public string Address { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public int EmployeeRoleId { get; set; }
    }
}
