using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class PolicyType
    {
        public PolicyType()
        {
            Policies = new HashSet<Policy>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte PolicyTypeId { get; set; }
        public string PolicyTypeName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
