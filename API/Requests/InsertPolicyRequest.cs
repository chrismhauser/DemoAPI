namespace API.Requests
{
    public class InsertPolicyRequest
    {
        public DateTime EffectiveDate { get; set; }
        public int PolicyTypeId { get; set; }
        public int PolicyStatusId { get; set; }
        public int CarrierId { get; set; }
        public int PaymentTermId { get; set; }
    }
}
