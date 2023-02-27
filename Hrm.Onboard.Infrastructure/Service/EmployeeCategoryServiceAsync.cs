using Hrm.Onboard.ApplicationCore.Contract.Repository;
using Hrm.Onboard.ApplicationCore.Contract.Service;
using Hrm.Onboard.ApplicationCore.Entity;
using Hrm.Onboard.ApplicationCore.Model.Request;
using Hrm.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.Infrastructure.Service
{
    public class EmployeeCategoryServiceAsync : IEmployeeCategoryServiceAsync
    {
        private readonly IEmployeeCategoryRepositoryAsync employeeCategoryRepositoryAsync;

        public EmployeeCategoryServiceAsync(IEmployeeCategoryRepositoryAsync _employeeCategoryRepositoryAsync)
        {
            employeeCategoryRepositoryAsync = _employeeCategoryRepositoryAsync;
        }


        public Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            EmployeeCategory employeeCategory = new EmployeeCategory()
            {
                Id = model.Id,
                Description = model.Description
            };
            return employeeCategoryRepositoryAsync.InsertAsync(employeeCategory);
        }

        public Task<int> DeleteEmployeeCategoryAsync(int id)
        {
            return employeeCategoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategoryAsync()
        {
            var result = await employeeCategoryRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeCategoryResponseModel
                {
                    Id = x.Id,
                    Description=x.Description
                });
            }
            return null;
        }

        public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id)
        {
            var result = await employeeCategoryRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeCategoryResponseModel()
                {
                    Id = result.Id,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            EmployeeCategory employeeCategory = new EmployeeCategory()
            {
                Id = model.Id,
                Description = model.Description
            };
            return employeeCategoryRepositoryAsync.UpdateAsync(employeeCategory);
        }
    }
}
