using Hrm.Interview.ApplicationCore.Contract.Repository;
using Hrm.Interview.ApplicationCore.Entity;
using Hrm.Interview.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.Infrastructure.Repository
{
    public class InterviewerRepositoryAsync : BaseRepositoryAsync<Interviewer>, IInterviewerRepositoryAsync
    {
        public InterviewerRepositoryAsync(InterviewDbContext _db) : base(_db)
        {
        }
    }
}
