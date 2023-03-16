using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.ApplicationCore.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }
        [Required, Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int EmployeeStatusId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Address { get; set; }
        [Required, Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public int EmployeeRoleId { get; set; }

        //Navigational property
        public EmployeeCategory EmployeeCategory { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
    }
}
