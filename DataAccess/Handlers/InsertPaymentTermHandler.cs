using Data.Commands;
using Data.Models;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class InsertPaymentTermHandler : IRequestHandler<InsertPaymentTermCommand, bool>
{
    private readonly IPaymentTermService _paymentTermService;

    public InsertPaymentTermHandler(IPaymentTermService paymentTermService)
    {
        _paymentTermService = paymentTermService;
    }

    public Task<bool> Handle(InsertPaymentTermCommand request, CancellationToken cancellationToken)
    {
        return _paymentTermService.InsertPaymentTermAsync(new PaymentTerm { PaymentTermName = request.PaymentTerm });
    }
}