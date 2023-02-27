using Hrm.Onboard.ApplicationCore.Contract.Repository;
using Hrm.Onboard.ApplicationCore.Entity;
using Hrm.Onboard.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Onboard.Infrastructure.Repository
{
    public class EmployeeRepositoryAsync : BaseRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
        public EmployeeRepositoryAsync(OnboardDbContext _db) : base(_db)
        {
        }
    }
}
