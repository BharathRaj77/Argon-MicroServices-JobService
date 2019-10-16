using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.EntityFramework.Models
{
    public class JobDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        [ForeignKey("Type")]
        public virtual JobType JobType { get; set; }
        public ICollection<ActionState> ActionStates { get; set; }
    }
}
