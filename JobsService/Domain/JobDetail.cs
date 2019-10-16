using Domain.Enums;
using Domain.Extensions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed class JobDetail
    {
        public int Id { get; set; }
        public string Identifier { get; private set; }
        public Name Name { get; private set; }
        public DateTime EffectiveStartDate { get; private set; }
        public string Description { get; private set; }
        public JobTypeEnum Type { get; private set; }
        public ActionState ActionState { get; private set; }
        public List<ActionState> ActionStates { get; private set; }

        public JobDetail(Name name, DateTime esd, string description, string jobType, ActionState actionState)
        {
            Name = name;
            Identifier = Extension.GetJobIdPrefix((JobTypeEnum)Enum.Parse(typeof(JobTypeEnum), jobType));
            EffectiveStartDate = esd;
            Description = description;
            Type = (JobTypeEnum)Enum.Parse(typeof(JobTypeEnum), jobType);
            ActionState = actionState;
        }
        private JobDetail() { }
        public static JobDetail LoadFromDetails(int id,string identifier,
            Name name, DateTime esd, string description, int jobType)
        {
            JobDetail jobDetail = new JobDetail
            {
                Id = id,
                Identifier = identifier,
                Name = name,
                EffectiveStartDate = esd,
                Description = description,
                Type = (JobTypeEnum)jobType// check this JobType - should it be int or string or enumType 
            };
            return jobDetail;
        }
    }
}
