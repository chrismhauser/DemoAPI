using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Carrier
    {
        public Carrier()
        {
            Policies = new HashSet<Policy>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CarrierId { get; set; }
        public string CarrierName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
