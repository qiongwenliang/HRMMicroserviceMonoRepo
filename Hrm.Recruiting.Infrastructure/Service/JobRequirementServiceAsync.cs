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
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        private readonly IJobRequirementRepositoryAsync jobRequirementRepositoryAsync;
        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync _jobRequirementRepositoryAsync)
        {
            jobRequirementRepositoryAsync = _jobRequirementRepositoryAsync;
        }

        public Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,    
                IsActive = model.IsActive,
                TotalPosition = model.TotalPosition,    
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,    
                StartDate = model.StartDate,
                CloseOn = model.CloseOn,
                CreatedOn = model.CreatedOn,    
                ClosingReason = model.ClosingReason,
                JobCategoryId = model.JobCategoryId,
                EmployementType = model.EmployementType
            };
            return jobRequirementRepositoryAsync.InsertAsync(jobRequirement);
        }

        public Task<int> DeleteJobRequirementAsync(int id)
        {
            return jobRequirementRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementAsync()
        {
            var result = await jobRequirementRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new JobRequirementResponseModel()
                {
                    Id  =x.Id,
                    Title=x.Title,
                    Description=x.Description,
                    TotalPosition=x.TotalPosition,
                    HiringManagerId=x.HiringManagerId,
                    HiringManagerName=x.HiringManagerName,
                    StartDate=x.StartDate,
                    CloseOn=x.CloseOn,
                    ClosingReason=x.ClosingReason,
                    IsActive=x.IsActive,
                    JobCategoryId = x.JobCategoryId,
                    EmployementType =x.EmployementType,
                    CreatedOn =x.CreatedOn
                });
            }
            return null;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var result = await jobRequirementRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new JobRequirementResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    TotalPosition = result.TotalPosition,
                    HiringManagerId = result.HiringManagerId,
                    HiringManagerName = result.HiringManagerName,
                    StartDate = result.StartDate,
                    CloseOn = result.CloseOn,
                    ClosingReason = result.ClosingReason,
                    IsActive = result.IsActive,
                    JobCategoryId = result.JobCategoryId,
                    EmployementType = result.EmployementType,
                    CreatedOn = result.CreatedOn
                };
            }
            return null;
        }

        public Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id=model.Id,
                Title=model.Title,
                TotalPosition = model.TotalPosition,
                HiringManagerId=model.HiringManagerId,
                HiringManagerName=model.HiringManagerName,
                StartDate=model.StartDate,
                ClosingReason = model.ClosingReason,
                IsActive=model.IsActive,
                JobCategoryId =model.JobCategoryId, 
                EmployementType=model.EmployementType,
                CreatedOn=model.CreatedOn
            };
            return jobRequirementRepositoryAsync.UpdateAsync(jobRequirement);
        }
    }
}
