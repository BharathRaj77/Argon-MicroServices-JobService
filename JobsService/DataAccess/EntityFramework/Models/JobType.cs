using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.EntityFramework.Models
{
    public class JobType
    {
        private JobType(JobTypeEnum jobTypeEnum)
        {
            Id = (int)jobTypeEnum;
            Name = jobTypeEnum.ToString();
        }
        protected JobType() { }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<JobDetail> JobDetails { get; set; }
        public static implicit operator JobType(JobTypeEnum @enum) => new JobType(@enum);
        public static implicit operator JobTypeEnum(JobType action) => (JobTypeEnum)action.Id;
    }
}
