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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }


        public Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                SSN = model.SSN,
                HireDate = model.HireDate,
                EndDate = model.EndDate,
                EmployeeCategoryId = model.EmployeeCategoryId,
                EmployeeStatusId = model.EmployeeStatusId,
                Address = model.Address,
                EmailAddress = model.EmailAddress,
                EmployeeRoleId = model.EmployeeRoleId
            };
            return employeeRepositoryAsync.InsertAsync(employee);
        }

        public Task<int> DeleteEmployeeAsync(int id)
        {
            return employeeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeResponseModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    SSN = x.SSN,
                    HireDate = x.HireDate,
                    EndDate = x.EndDate,
                    EmployeeCategoryId = x.EmployeeCategoryId,
                    EmployeeStatusId = x.EmployeeStatusId,
                    Address = x.Address,
                    EmailAddress = x.EmailAddress,
                    EmployeeRoleId = x.EmployeeRoleId
                });
            }
            return null;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var result = await employeeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    MiddleName = result.MiddleName,
                    SSN = result.SSN,
                    HireDate = result.HireDate,
                    EndDate = result.EndDate,
                    EmployeeCategoryId = result.EmployeeCategoryId,
                    EmployeeStatusId = result.EmployeeStatusId,
                    Address = result.Address,
                    EmailAddress = result.EmailAddress,
                    EmployeeRoleId = result.EmployeeRoleId
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                SSN = model.SSN,
                HireDate = model.HireDate,
                EndDate = model.EndDate,
                EmployeeCategoryId = model.EmployeeCategoryId,
                EmployeeStatusId = model.EmployeeStatusId,
                Address = model.Address,
                EmailAddress = model.EmailAddress,
                EmployeeRoleId = model.EmployeeRoleId
            };
            return employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}
