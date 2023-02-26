using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Model.Response
{
    public class JobRequirementResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalPosition { get; set; }
        public int HiringManagerId { get; set; }
        public string HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CloseOn { get; set; }
        public string? ClosingReason { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int JobCategoryId { get; set; }
        public int EmployementType { get; set; }
    }
}
