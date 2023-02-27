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
    public class InterviewsServiceAsync : IInterviewsServiceAsync
    {
        private readonly IInterviewsRepositoryAsync interviewsRepositoryAsync;
        public InterviewsServiceAsync(IInterviewsRepositoryAsync _interviewsRepositoryAsync)
        {
            interviewsRepositoryAsync = _interviewsRepositoryAsync;
        }
        public Task<int> AddInterviewsAsync(InterviewsRequestModel model)
        {
            Interviews interviews = new Interviews()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewRound = model.InterviewRound,
                RecruiterId = model.RecruiterId,
                ScheduledOn = model.ScheduledOn,
                InterviewerId = model.InterviewerId,
                InterviewFeedbackId = model.InterviewFeedbackId,
                InterviewTypeId = model.InterviewTypeId
            };
            return interviewsRepositoryAsync.InsertAsync(interviews);
        }

        public Task<int> DeleteInterviewsAsync(int id)
        {
            return interviewsRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewsResponseModel>> GetAllInterviewsAsync()
        {
            var result = await interviewsRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewsResponseModel()
                {
                    Id = x.Id,
                    SubmissionId = x.SubmissionId,
                    InterviewRound = x.InterviewRound,
                    RecruiterId = x.RecruiterId,
                    ScheduledOn = x.ScheduledOn,
                    InterviewerId = x.InterviewerId,
                    InterviewFeedbackId = x.InterviewFeedbackId,
                    InterviewTypeId = x.InterviewTypeId
                });
            }
            return null;
        }

        public async Task<InterviewsResponseModel> GetInterviewsByIdAsync(int id)
        {
            var result = await interviewsRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewsResponseModel()
                {
                    Id = result.Id,
                    SubmissionId = result.SubmissionId,
                    InterviewRound = result.InterviewRound,
                    RecruiterId = result.RecruiterId,
                    ScheduledOn = result.ScheduledOn,
                    InterviewerId = result.InterviewerId,
                    InterviewFeedbackId = result.InterviewFeedbackId,
                    InterviewTypeId = result.InterviewTypeId
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewsAsync(InterviewsRequestModel model)
        {
            Interviews interviews = new Interviews()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewRound = model.InterviewRound,
                RecruiterId = model.RecruiterId,
                ScheduledOn = model.ScheduledOn,
                InterviewerId = model.InterviewerId,
                InterviewFeedbackId = model.InterviewFeedbackId,
                InterviewTypeId = model.InterviewTypeId
            };
            return interviewsRepositoryAsync.UpdateAsync(interviews);
        }
    }
}
