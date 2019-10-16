using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.EntityFramework.Models
{
    public class Action
    {
        private Action(ActionTypeEnum actionTypeEnum)
        {
            Id = (int)actionTypeEnum;
            Name = actionTypeEnum.ToString();
        }
        protected Action() { }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ActionState> ActionState { get; set; }

        public static implicit operator Action(ActionTypeEnum @enum) => new Action(@enum);
        public static implicit operator ActionTypeEnum(Action action) => (ActionTypeEnum)action.Id;
    }
}
