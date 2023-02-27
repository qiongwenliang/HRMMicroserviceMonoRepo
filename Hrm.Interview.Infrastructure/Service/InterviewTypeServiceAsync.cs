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
    public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {
        private readonly IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;
        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
        {
            interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }

    
        public Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Description = model.Description,
            };
            return interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public Task<int> DeleteInterviewTypeAsync(int id)
        {
            return interviewTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypeAsync()
        {
            var result = await interviewTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewTypeResponseModel()
                {
                    Id = x.Id,
                    Description=x.Description                   
                });
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var result = await interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Description = model.Description
            };
            return interviewTypeRepositoryAsync.UpdateAsync(interviewType);
        }
    }
}
