using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.UpdateActionState
{
    public class UpdateRequest
    {
        public string ActionType { get; set; }
        public int JobId { get; set; }
        public string JobStatus { get; set; }
        //public DateTime ActionDateTime { get; } check this
        public string UserName { get; }
        public int EIN { get; }
        public string Notes { get; set; }
    }
}
