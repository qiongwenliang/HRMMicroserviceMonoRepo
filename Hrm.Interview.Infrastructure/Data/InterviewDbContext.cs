using Hrm.Interview.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.Infrastructure.Data
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options)
        {

        }

        public DbSet<Interviews> Interviews { get; set; }
        public DbSet<Interviewer> Interviewer { get; set; }
        public DbSet<InterviewType> InterviewType { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; }

    }
}
