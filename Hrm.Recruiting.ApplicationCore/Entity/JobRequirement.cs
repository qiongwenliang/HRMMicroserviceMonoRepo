using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Entity
{
    public class JobRequirement
    {
        public int Id { get; set; }
        [Required]
        [Column("varchar(150)")]
        public string Title { get; set; }
        [Required]
        [Column("varchar(500)")]
        public string Description { get; set; }
        [Required]
        public int TotalPosition { get; set; }
        [Required]
        public int HiringManagerId { get; set; }
        //They come from different APILayer
        [Required, Column("varchar(100)")]
        public string HiringManagerName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CloseOn { get; set; }
        public string? ClosingReason { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;//this is a default value it will take the time that this table is created
        [Required]
        public int JobCategoryId { get; set; }

        public int EmployementType { get; set; }//we can use enums here. create it in APILayer, define enums, and get values there

        //Navigational Property
        public JobCategory JobCategory { get; set; }
    }
}
