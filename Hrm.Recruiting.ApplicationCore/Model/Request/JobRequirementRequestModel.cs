using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Model.Request
{
    public class JobRequirementRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Total Position is required")]
        public int TotalPosition { get; set; }
        [Required(ErrorMessage ="Hiring Manager Id is required")]
        public int HiringManagerId { get; set; }
        [Required(ErrorMessage ="Hiring Manager Name is required")]
        public string HiringManagerName { get; set; }
        [Required(ErrorMessage ="Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage ="Please tell if this position is still actively recruiting")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage ="Closing Date is required")]
        public DateTime CloseOn { get; set; }
        public string? ClosingReason { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required(ErrorMessage ="Job Category Id is required")]
        public int JobCategoryId { get; set; }

        public int EmployementType { get; set; }
    }
}
