using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.EntityFramework.Models
{
    public class Status
    {
        private Status(StatusTypeEnum statusTypeEnum)
        {
            Id = (int)statusTypeEnum;
            Name = statusTypeEnum.ToString();
        }
        protected Status() { }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ActionState> ActionState { get; set; }
        public static implicit operator Status(StatusTypeEnum statusTypeEnum) => new Status(statusTypeEnum);
        public static implicit operator StatusTypeEnum(Status status) => (StatusTypeEnum)status.Id;
    }
}
