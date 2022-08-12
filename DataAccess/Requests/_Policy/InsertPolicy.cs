using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Policy;

public record InsertPolicyCommand(
    string PolicyNumber,
    DateTime EffectiveDate,
    int PolicyTypeId,
    int PolicyStatusId,
    int CarrierId,
    int PaymentTermId
) : IRequest<bool>;

public class InsertPolicyHandler : IRequestHandler<InsertPolicyCommand, bool>
{
    private readonly IPolicyService _policyService;

    public InsertPolicyHandler(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    public async Task<bool> Handle(InsertPolicyCommand request, CancellationToken cancellationToken)
    {
        return await _policyService.InsertPolicyAsync(new Policy
        {
            PolicyNumber = request.PolicyNumber,
            EffectiveDate = request.EffectiveDate.Date,
            ExpirationDate = request.EffectiveDate.AddYears(1).Date,
            PolicyTypeId = Convert.ToByte(request.PolicyTypeId),
            PolicyStatusId = Convert.ToByte(request.PolicyStatusId),
            CarrierId = Convert.ToByte(request.CarrierId),
            PaymentTermId = Convert.ToByte(request.PaymentTermId)
        });
    }
}