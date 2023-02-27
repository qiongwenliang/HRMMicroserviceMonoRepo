using Hrm.Onboard.ApplicationCore.Model.Request;
using Hrm.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.ApplicationCore.Contract.Service
{
    public interface IEmployeeStatusServiceAsync
    {
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> DeleteEmployeeStatusAsync(int id);
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id);
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync();
    }
}
