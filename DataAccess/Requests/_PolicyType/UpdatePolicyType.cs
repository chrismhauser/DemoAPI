using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyType;

public record UpdatePolicyTypeCommand(int PolicyTypeId, string PolicyType) : IRequest<bool>;

public class UpdatePolicyTypeHandler : IRequestHandler<UpdatePolicyTypeCommand, bool>
{
    private readonly IPolicyTypeService _policyTypeService;

    public UpdatePolicyTypeHandler(IPolicyTypeService policyTypeService)
    {
        _policyTypeService = policyTypeService;
    }

    public async Task<bool> Handle(UpdatePolicyTypeCommand request, CancellationToken cancellationToken)
    {
        var policyType = await _policyTypeService.GetPolicyTypeAsync(request.PolicyTypeId);
        if (policyType is null) return false;

        policyType.PolicyTypeName = request.PolicyType;

        return await _policyTypeService.UpdatePolicyTypeAsync(policyType);
    }
}