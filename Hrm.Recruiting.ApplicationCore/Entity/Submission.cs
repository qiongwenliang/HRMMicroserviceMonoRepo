using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Entity
{
    public class Submission
    {
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public int CandidateId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public int SubmissionStatusCode { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }

        //Navigational property
        public Candidate Candidate { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
    }
}
