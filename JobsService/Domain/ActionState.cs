using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ActionState
    {
        public int Id { get; set; }
        public ActionTypeEnum Action { get; private set; }
        public int JobId { get; set; }
        public StatusTypeEnum Status { get; private set; }
        public DateTime ActionDateTime { get; private set; }
        public string UserName { get; private set; }
        public int EIN { get; private set; }
        public string Notes { get; private set; }

        public ActionState(string action, string status, DateTime actionDatetime, string notes)
        {
            Action = (ActionTypeEnum)Enum.Parse(typeof(ActionTypeEnum), action);
            Status = (StatusTypeEnum)Enum.Parse(typeof(StatusTypeEnum), status);
            ActionDateTime = actionDatetime;
            Notes = notes;
        }
        public ActionState(string action, string status, DateTime actionDatetime, string notes, int jobId)
        {
            Action = (ActionTypeEnum)Enum.Parse(typeof(ActionTypeEnum), action);
            Status = (StatusTypeEnum)Enum.Parse(typeof(StatusTypeEnum), status);
            ActionDateTime = actionDatetime;
            Notes = notes;
            JobId = jobId;
        }
    }
}
