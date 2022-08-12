using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PaymentTerm;

public record InsertPaymentTermCommand(string PaymentTerm) : IRequest<bool>;

public class InsertPaymentTermHandler : IRequestHandler<InsertPaymentTermCommand, bool>
{
    private readonly IPaymentTermService _paymentTermService;

    public InsertPaymentTermHandler(IPaymentTermService paymentTermService)
    {
        _paymentTermService = paymentTermService;
    }

    public async Task<bool> Handle(InsertPaymentTermCommand request, CancellationToken cancellationToken)
    {
        return await _paymentTermService.InsertPaymentTermAsync(new PaymentTerm { PaymentTermName = request.PaymentTerm });
    }
}