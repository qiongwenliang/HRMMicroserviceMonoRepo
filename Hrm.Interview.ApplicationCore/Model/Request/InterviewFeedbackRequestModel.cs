﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Interview.ApplicationCore.Model.Request
{
    public class InterviewFeedbackRequestModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
