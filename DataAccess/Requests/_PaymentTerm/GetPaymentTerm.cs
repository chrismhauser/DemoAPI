using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PaymentTerm;

public record GetPaymentTermQuery(int PaymentTermId) : IRequest<PaymentTerm>;

public class GetPaymentTermHandler : IRequestHandler<GetPaymentTermQuery, PaymentTerm>
{
    private readonly IPaymentTermService _paymentTermService;

    public GetPaymentTermHandler(IPaymentTermService paymentTermService)
    {
        _paymentTermService = paymentTermService;
    }

    public async Task<PaymentTerm> Handle(GetPaymentTermQuery request, CancellationToken cancellationToken)
    {
        return await _paymentTermService.GetPaymentTermAsync(request.PaymentTermId);
    }
}