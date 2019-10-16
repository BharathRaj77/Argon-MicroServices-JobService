using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.CreateJob
{
    public class CreateRequest
    {
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public string JobType { get; set; } // check this
        public string Action { get; set; }
        public string JobStatus { get; set; }
        public string Notes { get; set; }
       // user details yet to be decided
    }
}
