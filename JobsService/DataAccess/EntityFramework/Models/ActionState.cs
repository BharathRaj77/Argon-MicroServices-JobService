using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.EntityFramework.Models
{
    public class ActionState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int JobId { get; set; }
        public int StatusId { get; set; }
        public DateTime ActionDateTime { get; set; }
        public string UserName { get; set; }
        public int EIN { get; set; }
        public string Notes { get; set; }
        [ForeignKey("ActionId")]
        public virtual Action Action { get; set; }
        [ForeignKey("JobId")]
        public virtual JobDetail JobDetail { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}
