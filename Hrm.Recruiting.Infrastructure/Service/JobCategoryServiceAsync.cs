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
    public class JobCategoryServiceAsync : IJobCategoryServiceAsync
    {
        private readonly IJobCategoryRepositoryAsync jobCategoryRepositoryAsync;
        public JobCategoryServiceAsync(IJobCategoryRepositoryAsync _jobCategoryRepositoryAsync)
        {
            jobCategoryRepositoryAsync = _jobCategoryRepositoryAsync;
        }
        
        public Task<int> AddJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory() 
            {
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive,
            };
            return jobCategoryRepositoryAsync.InsertAsync(jobCategory);
        }

        public Task<int> DeleteJobCategoryAsync(int id)
        {
            return jobCategoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobCategoryResponseModel>> GetAllJobCategoryAsync()
        {
            var result = await jobCategoryRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new JobCategoryResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description= x.Description,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<JobCategoryResponseModel> GetJobCategoryByIdAsync(int id)
        {
            var result = await jobCategoryRepositoryAsync.GetByIdAsync(id); 
            if (result != null)
            {
                return new JobCategoryResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Id = model.Id,
                Title= model.Title,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.UpdateAsync(jobCategory);
        }
    }
}
