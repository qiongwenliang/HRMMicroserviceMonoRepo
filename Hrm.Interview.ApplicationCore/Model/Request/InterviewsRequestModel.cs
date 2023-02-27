using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.Model.Request
{
    public class InterviewsRequestModel
    {
        public int Id { get; set; }
        public int RecruiterId { get; set; }
        public int SubmissionId { get; set; }
        public int InterviewTypeId { get; set; }
        public int InterviewRound { get; set; }
        public DateTime ScheduledOn { get; set; }
        public int InterviewerId { get; set; }
        public int InterviewFeedbackId { get; set; }
    }
}
