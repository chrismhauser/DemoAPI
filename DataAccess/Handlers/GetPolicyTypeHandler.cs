using Data.Models;
using Data.Queries;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class GetPolicyTypeHandler : IRequestHandler<GetPolicyTypeQuery, PolicyType>
{
    private readonly IPolicyTypeService _policyTypeService;

    public GetPolicyTypeHandler(IPolicyTypeService policyTypeService)
    {
        _policyTypeService = policyTypeService;
    }

    public Task<PolicyType> Handle(GetPolicyTypeQuery request, CancellationToken cancellationToken)
    {
        return _policyTypeService.GetPolicyTypeAsync(request.PolicyTypeId);
    }
}