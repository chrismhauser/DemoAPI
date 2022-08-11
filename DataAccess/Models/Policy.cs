using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Policy
    {
        
        public int PolicyId { get; }
        public string PolicyNumber { get; set; } = null!;
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte PolicyTypeId { get; set; }
        public byte PolicyStatusId { get; set; }
        public byte CarrierId { get; set; }
        public byte PaymentTermId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        public virtual Carrier Carrier { get; set; } = null!;
        public virtual PaymentTerm PaymentTerm { get; set; } = null!;
        public virtual PolicyStatus PolicyStatus { get; set; } = null!;
        public virtual PolicyType PolicyType { get; set; } = null!;
    }
}
