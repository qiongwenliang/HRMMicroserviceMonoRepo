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
    public class CandidateServiceAsync : ICandidateServiceAsync
    {
        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;
        private readonly IBlobServiceAsync blobServiceAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync, IBlobServiceAsync _blobServiceAsync)
        {
            candidateRepositoryAsync = _candidateRepositoryAsync;
            blobServiceAsync = _blobServiceAsync;
        }


        public Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                Mobile = model.Mobile
            };
            return candidateRepositoryAsync.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(int id)
        {
            return candidateRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync()
        {
            var result = await candidateRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new CandidateResponseModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailId = x.EmailId,
                    Mobile = x.Mobile
                });
            }
            return null;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var result = await candidateRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new CandidateResponseModel
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Id = result.Id,
                    EmailId = result.EmailId,
                    Mobile = result.Mobile
                };
            }
            return null;
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var result = await blobServiceAsync.UploadFileAsync(model.ResumeUrl, model.FileName);

            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName=model.LastName,
                Mobile = model.Mobile,
                EmailId=model.EmailId,
                ResumeUrl = model.ResumeUrl
            };
            return await candidateRepositoryAsync.UpdateAsync(candidate);
        }
    }
}
