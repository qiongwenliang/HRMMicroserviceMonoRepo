using Hrm.Authentication.ApplicationCore.Model.Request;
using Hrm.Authentication.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Authentication.ApplicationCore.Contract.Service
{
    public interface IUserServiceAsync
    {
        Task<int> AddUserAsync(UserRequestModel model);
        Task<int> UpdateUserAsync(UserRequestModel model);
        Task<int> DeleteUserAsync(int id);
        Task<UserResponseModel> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseModel>> GetAllUserAsync();
    }
}
