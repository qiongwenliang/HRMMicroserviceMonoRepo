using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.ModelRef
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int EmployeeStatusId { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int EmployeeRoleId { get; set; }
    }
}
