using Data.Models;
using Data.Queries;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class GetPaymentTermHandler : IRequestHandler<GetPaymentTermQuery, PaymentTerm>
{
    private readonly IPaymentTermService _paymentTermService;

    public GetPaymentTermHandler(IPaymentTermService paymentTermService)
    {
        _paymentTermService = paymentTermService;
    }

    public Task<PaymentTerm> Handle(GetPaymentTermQuery request, CancellationToken cancellationToken)
    {
        return _paymentTermService.GetPaymentTermAsync(request.PaymentTermId);
    }
}