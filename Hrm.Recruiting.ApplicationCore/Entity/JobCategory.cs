using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Entity
{
    public class JobCategory
    {
        public int Id { get; set; }
        [Required, Column("varchar(30)")]
        public string Title { get; set; }
        [Required, Column("varchar(500)")]
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
