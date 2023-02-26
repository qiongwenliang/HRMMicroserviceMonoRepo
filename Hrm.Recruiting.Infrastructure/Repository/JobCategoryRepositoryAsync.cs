using Hrm.Recruiting.ApplicationCore.Contract.Repository;
using Hrm.Recruiting.ApplicationCore.Entity;
using Hrm.Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.Infrastructure.Repository
{
    public class JobCategoryRepositoryAsync : BaseRepositoryAsync<JobCategory>, IJobCategoryRepositoryAsync
    {
        public JobCategoryRepositoryAsync(RecruitmentDbContext _context) : base(_context)
        {
        }
    }
}
