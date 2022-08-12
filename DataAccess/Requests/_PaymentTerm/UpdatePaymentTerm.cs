using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PaymentTerm;

public record UpdatePaymentTermCommand(int PaymentTermId, string PaymentTerm) : IRequest<bool>;

public class UpdatePaymentTermHandler : IRequestHandler<UpdatePaymentTermCommand, bool>
{
    private readonly IPaymentTermService _paymentTermService;

    public UpdatePaymentTermHandler(IPaymentTermService paymentTermService)
    {
        _paymentTermService = paymentTermService;
    }

    public async Task<bool> Handle(UpdatePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var paymentTerm = await _paymentTermService.GetPaymentTermAsync(request.PaymentTermId);
        if (paymentTerm is null) return false;

        paymentTerm.PaymentTermName = request.PaymentTerm;

        return await _paymentTermService.UpdatePaymentTermAsync(paymentTerm);
    }
}