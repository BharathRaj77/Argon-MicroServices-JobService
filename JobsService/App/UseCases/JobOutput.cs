using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.UseCases
{
    public sealed class JobOutput
    {
        public int JobId { get; }
        public string Identifier { get;}
        public string JobName { get;}
        public DateTime JobEffectiveStartDate { get;}
        public string JobDescription { get;}
        public string JobType { get; private set; }
        public IReadOnlyList<ActionStateOutput> ActionStates { get;}

        public JobOutput(JobDetail jobDetail)
        {
            JobId = jobDetail.Id;
            Identifier = jobDetail.Identifier;
            JobName = jobDetail.Name;
            JobEffectiveStartDate = jobDetail.EffectiveStartDate;
            JobDescription = jobDetail.Description;
            JobType = jobDetail.Type.ToString();
        }
    }
}
