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
    public class SubmissionStatusServiceAsync : ISubmissionStatusServiceAsync
    {
        private readonly ISubmissionStatusRepositoryAsync submissionStatusRepositoryAsync;
        public SubmissionStatusServiceAsync(ISubmissionStatusRepositoryAsync _submissionStatusRepositoryAsync)
        {
            submissionStatusRepositoryAsync = _submissionStatusRepositoryAsync;
        }


        public Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus submissionStatus = new SubmissionStatus()
            {
                Id = model.Id,
                Description = model.Description
            };
            return submissionStatusRepositoryAsync.InsertAsync(submissionStatus);
        }

        public Task<int> DeleteSubmissionStatusAsync(int id)
        {
            return submissionStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatusAsync()
        {
            var result = await submissionStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new SubmissionStatusResponseModel()
                {
                    Description = x.Description,
                    Id = x.Id
                });
            }
            return null;
        }

        public async Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id)
        {
            var result = await submissionStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new SubmissionStatusResponseModel()
                {
                    Id = result.Id,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus submissionStatus = new SubmissionStatus()
            {
                Id = model.Id,
                Description = model.Description
            };
            return submissionStatusRepositoryAsync.UpdateAsync(submissionStatus);
        }
    }
}
