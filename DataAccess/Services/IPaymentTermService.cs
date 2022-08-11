using Data.Models;

namespace Data.Services;

public interface IPaymentTermService
{
    Task<PaymentTerm> GetPaymentTermAsync(int paymentTermId);
    Task<bool> InsertPaymentTermAsync(PaymentTerm paymentTerm);
}