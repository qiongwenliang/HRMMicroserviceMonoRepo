using Hrm.Interview.ApplicationCore.Model.Request;
using Hrm.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewerServiceAsync
    {
        Task<int> AddInterviewerAsync(InterviewerRequestModel model);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
        Task<int> DeleteInterviewerAsync(int id);
        Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewerAsync();
    }
}
