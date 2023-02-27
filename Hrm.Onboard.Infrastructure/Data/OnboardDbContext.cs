using Hrm.Onboard.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.Infrastructure.Data
{
    public class OnboardDbContext : DbContext
    {
        public OnboardDbContext(DbContextOptions<OnboardDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategory { get; set; }
        public DbSet<EmployeeRole> EmployeeRole { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
    }
}
