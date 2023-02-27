using Hrm.Onboard.ApplicationCore.Model.Request;
using Hrm.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.ApplicationCore.Contract.Service
{
    public interface IEmployeeCategoryServiceAsync
    {
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> DeleteEmployeeCategoryAsync(int id);
        Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id);
        Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategoryAsync();
    }
}
