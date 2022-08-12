using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Policy;

public record UpdatePolicyCommand(
    int PolicyId,
    string PolicyNumber,
    DateTime EffectiveDate,
    int PolicyTypeId,
    int PolicyStatusId,
    int CarrierId,
    int PaymentTermId
) : IRequest<bool>;

public class UpdatePolicyHandler : IRequestHandler<UpdatePolicyCommand, bool>
{
    private readonly IPolicyService _policyService;

    public UpdatePolicyHandler(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    public async Task<bool> Handle(UpdatePolicyCommand request, CancellationToken cancellationToken)
    {
        var policy = await _policyService.GetPolicyAsync(request.PolicyId);
        if (policy == null) return false;

        policy.PolicyNumber = request.PolicyNumber;
        policy.EffectiveDate = request.EffectiveDate.Date;
        policy.ExpirationDate = request.EffectiveDate.AddYears(1).Date;
        policy.PolicyTypeId = Convert.ToByte(request.PolicyTypeId);
        policy.PolicyStatusId = Convert.ToByte(request.PolicyStatusId);
        policy.CarrierId = Convert.ToByte(request.CarrierId);
        policy.PaymentTermId = Convert.ToByte(request.PaymentTermId);

        return await _policyService.UpdatePolicyAsync(policy);
    }
}