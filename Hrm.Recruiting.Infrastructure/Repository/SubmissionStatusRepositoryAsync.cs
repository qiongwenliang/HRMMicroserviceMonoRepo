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
    public class SubmissionStatusRepositoryAsync : BaseRepositoryAsync<SubmissionStatus>, ISubmissionStatusRepositoryAsync
    {
        public SubmissionStatusRepositoryAsync(RecruitmentDbContext _context) : base(_context)
        {
        }
    }
}
