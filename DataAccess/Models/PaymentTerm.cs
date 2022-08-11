using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class PaymentTerm
    {
        public PaymentTerm()
        {
            Policies = new HashSet<Policy>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte PaymentTermId { get; set; }
        public string PaymentTermName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
