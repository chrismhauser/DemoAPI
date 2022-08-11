using Data.Commands;
using Data.Models;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class InsertPolicyHandler : IRequestHandler<InsertPolicyCommand, bool>
{
    private readonly IPolicyService _policyService;

    public InsertPolicyHandler(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    public Task<bool> Handle(InsertPolicyCommand request, CancellationToken cancellationToken)
    {
        return _policyService.InsertPolicyAsync(new Policy
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