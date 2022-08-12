using Data.Models;

namespace Data.Services.Interfaces;

public interface IPaymentTermService
{
    Task<PaymentTerm> GetPaymentTermAsync(int paymentTermId);
    Task<List<PaymentTerm>> GetAllPaymentTermsAsync();
    Task<bool> InsertPaymentTermAsync(PaymentTerm paymentTerm);
    Task<bool> UpdatePaymentTermAsync(PaymentTerm paymentTerm);
}