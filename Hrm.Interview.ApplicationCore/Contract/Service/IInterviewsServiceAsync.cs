using Hrm.Interview.ApplicationCore.Model.Request;
using Hrm.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewsServiceAsync
    {
        Task<int> AddInterviewsAsync(InterviewsRequestModel model);
        Task<int> UpdateInterviewsAsync(InterviewsRequestModel model);
        Task<int> DeleteInterviewsAsync(int id);
        Task<InterviewsResponseModel> GetInterviewsByIdAsync(int id);
        Task<IEnumerable<InterviewsResponseModel>> GetAllInterviewsAsync();
    }
}
