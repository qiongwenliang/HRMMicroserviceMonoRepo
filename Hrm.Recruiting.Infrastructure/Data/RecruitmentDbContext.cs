using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hrm.Recruiting.ApplicationCore.Entity;

namespace Hrm.Recruiting.Infrastructure.Data
{
    public class RecruitmentDbContext : DbContext
    {
        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> option) : base(option)
        {

        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<JobRequirement> JobRequirement { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
    }
}
