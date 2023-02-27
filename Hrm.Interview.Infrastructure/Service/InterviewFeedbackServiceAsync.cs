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
    public class InterviewFeedbackServiceAsync : IInterviewFeedbackServiceAsync
    {
        private readonly IInterviewFeedbackRepositoryAsync interviewFeedbackRepositoryAsync;
        public InterviewFeedbackServiceAsync(IInterviewFeedbackRepositoryAsync _interviewFeedbackRepositoryAsync)
        {
            interviewFeedbackRepositoryAsync = _interviewFeedbackRepositoryAsync;
        }


        public Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            InterviewFeedback interviewFeedback = new InterviewFeedback()
            {
                Id = model.Id,
                Comment = model.Comment,
                Rating = model.Rating
            };
            return interviewFeedbackRepositoryAsync.InsertAsync(interviewFeedback);
        }

        public Task<int> DeleteInterviewFeedbackAsync(int id)
        {
            return interviewFeedbackRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbackAsync()
        {
            var result = await interviewFeedbackRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewFeedbackResponseModel()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Rating = x.Rating
                });
            }
            return null;
        }

        public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id)
        {
            var result = await interviewFeedbackRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewFeedbackResponseModel()
                {
                    Id = result.Id,
                    Comment = result.Comment,
                    Rating = result.Rating
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            InterviewFeedback interviewFeedback = new InterviewFeedback()
            {
                Id = model.Id,
                Comment = model.Comment,
                Rating = model.Rating
            };
            return interviewFeedbackRepositoryAsync.UpdateAsync(interviewFeedback);
        }
    }
}
