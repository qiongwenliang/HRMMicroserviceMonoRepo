using Hrm.Recruiting.ApplicationCore.Contract.Repository;
using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.ApplicationCore.Entity;
using Hrm.Recruiting.ApplicationCore.Model.Request;
using Hrm.Recruiting.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.Infrastructure.Service
{
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        private readonly ISubmissionRepositoryAsync submissonRepositoryAsync;
        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissonRepositoryAsync)
        {
            submissonRepositoryAsync = _submissonRepositoryAsync;
        }


        public Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                JobRequirementId = model.JobRequirementId,
                SubmissionStatusCode = model.SubmissionStatusCode,
                CandidateId = model.CandidateId,
                SubmittedOn = model.SubmittedOn,
                ConfirmedOn = model.ConfirmedOn,
                RejectedOn = model.RejectedOn
            };
            return submissonRepositoryAsync.InsertAsync(submission);
        }

        public Task<int> DeleteSubmissionAsync(int id)
        {
            return submissonRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync()
        {
            var result = await submissonRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new SubmissionResponseModel()
                {
                    Id =x.Id,
                    JobRequirementId = x.JobRequirementId,
                    SubmissionStatusCode = x.SubmissionStatusCode,
                    CandidateId=x.CandidateId,  
                    SubmittedOn = x.SubmittedOn,
                    ConfirmedOn=x.ConfirmedOn,
                    RejectedOn=x.RejectedOn
                });
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var result = await submissonRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new SubmissionResponseModel()
                {
                    Id =result.Id,
                    SubmissionStatusCode = result.SubmissionStatusCode,
                    JobRequirementId =result.JobRequirementId,
                    CandidateId =result.CandidateId,
                    SubmittedOn = result.SubmittedOn,
                    ConfirmedOn = result.ConfirmedOn,
                    RejectedOn = result.RejectedOn

                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                SubmissionStatusCode = model.SubmissionStatusCode,
                JobRequirementId=model.JobRequirementId,
                CandidateId=model.CandidateId,
                SubmittedOn = model.SubmittedOn,
                ConfirmedOn = model.ConfirmedOn,
                RejectedOn= model.RejectedOn
            };
            return submissonRepositoryAsync.UpdateAsync(submission);
        }
    }
}
