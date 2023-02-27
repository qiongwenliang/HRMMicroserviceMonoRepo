using Hrm.Authentication.ApplicationCore.Contract.Repository;
using Hrm.Authentication.ApplicationCore.Contract.Service;
using Hrm.Authentication.ApplicationCore.Entity;
using Hrm.Authentication.ApplicationCore.Model.Request;
using Hrm.Authentication.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Authentication.Infrastructure.Service
{
    public class UserRoleServiceAsync : IUserRoleServiceAsync
    {
        private readonly IUserRoleRepositoryAsync userRoleRepositoryAsync;
        public UserRoleServiceAsync(IUserRoleRepositoryAsync _userRoleRepositoryAsync)
        {
            userRoleRepositoryAsync = _userRoleRepositoryAsync;
        }

        public Task<int> AddUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole()
            {
                Id = model.Id,
                UserId = model.UserId,
                RoleId = model.RoleId
            };
            return userRoleRepositoryAsync.InsertAsync(userRole);
        }

        public Task<int> DeleteUserRoleAsync(int id)
        {
            return userRoleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoleAsync()
        {
            var result = await userRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new UserRoleResponseModel()
                {
                    RoleId = x.Id,
                    UserId = x.UserId,
                    Id = x.Id
                });
            }
            return null;
        }

        public async Task<UserRoleResponseModel> GetUserRoleByIdAsync(int id)
        {
            var result = await userRoleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new UserRoleResponseModel()
                {
                    UserId = result.UserId,
                    RoleId = result.RoleId,
                    Id = result.Id
                };
            }
            return null;
        }

        public Task<int> UpdateUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole()
            {
                Id = model.Id,
                RoleId = model.RoleId,
                UserId = model.UserId
            };
            return userRoleRepositoryAsync.UpdateAsync(userRole);
        }
    }
}
