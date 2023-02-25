using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Entity
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required, Column("varchar(25)")]
        public string FirstName { get; set; }
        [Required, Column("varchar(26)")]
        public string LastName { get; set; }
        [Required, Column("varchar(15)"), DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string? ResumeUrl { get; set; }
    }
}