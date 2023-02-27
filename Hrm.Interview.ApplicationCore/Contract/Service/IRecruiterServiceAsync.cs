using Hrm.Interview.ApplicationCore.Model.Request;
using Hrm.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.Contract.Service
{
    public interface IRecruiterServiceAsync
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiterAsync();
    }
}
