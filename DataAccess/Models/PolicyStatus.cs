using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class PolicyStatus
    {
        public PolicyStatus()
        {
            Policies = new HashSet<Policy>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte PolicyStatusId { get; set; }
        public string PolicyStatusName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
