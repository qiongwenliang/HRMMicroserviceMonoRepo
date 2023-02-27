using Hrm.Interview.ApplicationCore.Contract.Repository;
using Hrm.Interview.ApplicationCore.Contract.Service;
using Hrm.Interview.ApplicationCore.Entity;
using Hrm.Interview.ApplicationCore.Model.Request;
using Hrm.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.Infrastructure.Service
{
    public class InterviewerServiceAsync : IInterviewerServiceAsync
    {
        private readonly IInterviewerRepositoryAsync interviewerRepositoryAsync;
        public InterviewerServiceAsync(IInterviewerRepositoryAsync _interviewerRepositoryAsync)
        {
            interviewerRepositoryAsync = _interviewerRepositoryAsync;
        }

        public Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            Interviewer interviewer = new Interviewer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeID = model.EmployeeID
            };
            return interviewerRepositoryAsync.InsertAsync(interviewer);
        }

        public Task<int> DeleteInterviewerAsync(int id)
        {
            return interviewerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewerAsync()
        {
            var result = await interviewerRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewerResponseModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmployeeID = x.EmployeeID
                });
            }
            return null;
        }

        public async Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id)
        {
            var result = await interviewerRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewerResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmployeeID = result.EmployeeID
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            Interviewer interviewer = new Interviewer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeID = model.EmployeeID
            };
            return interviewerRepositoryAsync.UpdateAsync(interviewer);
        }
    }
}
