using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PaymentTerm;

public record GetAllPaymentTermsQuery() : IRequest<List<PaymentTerm>>;

public class GetAllPaymentTermsHandler : IRequestHandler<GetAllPaymentTermsQuery, List<PaymentTerm>>
{
    private readonly IPaymentTermService _paymentTermService;

    public GetAllPaymentTermsHandler(IPaymentTermService paymentTermService)
    {
        _paymentTermService = paymentTermService;
    }

    public async Task<List<PaymentTerm>> Handle(GetAllPaymentTermsQuery request, CancellationToken cancellationToken)
    {
        return await _paymentTermService.GetAllPaymentTermsAsync();
    }
}