using Hrm.Authentication.ApplicationCore.Contract.Repository;
using Hrm.Authentication.ApplicationCore.Entity;
using Hrm.Authentication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Authentication.Infrastructure.Repository
{
    public class UserRoleRepositoryAsync : BaseRepositoryAsync<UserRole>, IUserRoleRepositoryAsync
    {
        public UserRoleRepositoryAsync(AuthenticationDbContext _context) : base(_context)
        {
        }
    }
}
