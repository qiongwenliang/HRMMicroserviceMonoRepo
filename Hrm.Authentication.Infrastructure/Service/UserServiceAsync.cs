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
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync userRepositoryAsync;

        public UserServiceAsync(IUserRepositoryAsync _userRepositoryAsync)
        {
            userRepositoryAsync = _userRepositoryAsync;
        }

        public Task<int> AddUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                EmailId = model.EmailId,
                RoleId = model.RoleId,  
                FirstName = model.FirstName,
                LastName = model.LastName,
                HashPassword = model.HashPassword,
                Salt = model.Salt
            };
            return userRepositoryAsync.InsertAsync(user);
        }

        public Task<int> DeleteUserAsync(int id)
        {
            return userRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUserAsync()
        {
            var result = await userRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new UserResponseModel()
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    EmailId = x.EmailId,
                    RoleId = x.RoleId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    HashPassword = x.HashPassword,
                    Salt = x.Salt
                });
            }
            return null;
        }

        public async Task<UserResponseModel> GetUserByIdAsync(int id)
        {
            var result = await userRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new UserResponseModel()
                {
                    Id = result.Id,
                    EmployeeId = result.EmployeeId,
                    EmailId = result.EmailId,
                    RoleId = result.RoleId,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    HashPassword = result.HashPassword,
                    Salt = result.Salt
                };
            }
            return null;
        }

        public Task<int> UpdateUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                EmailId = model.EmailId,
                RoleId = model.RoleId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HashPassword = model.HashPassword,
                Salt = model.Salt
            };
            return userRepositoryAsync.UpdateAsync(user);
        }
    }
}
