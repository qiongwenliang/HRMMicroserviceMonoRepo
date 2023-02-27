using Hrm.Authentication.ApplicationCore.Model.Request;
using Hrm.Authentication.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Authentication.ApplicationCore.Contract.Service
{
    public interface IRoleServiceAsync 
    {
        Task<int> AddRoleAsync(RoleRequestModel model);
        Task<int> UpdateRoleAsync(RoleRequestModel model);
        Task<int> DeleteRoleAsync(int id);
        Task<RoleResponseModel> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleResponseModel>> GetAllRoleAsync();
    }
}
