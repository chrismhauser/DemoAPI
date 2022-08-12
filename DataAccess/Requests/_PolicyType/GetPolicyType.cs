using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyType;

public record GetPolicyTypeQuery(int PolicyTypeId) : IRequest<PolicyType>;

public class GetPolicyTypeHandler : IRequestHandler<GetPolicyTypeQuery, PolicyType>
{
    private readonly IPolicyTypeService _policyTypeService;

    public GetPolicyTypeHandler(IPolicyTypeService policyTypeService)
    {
        _policyTypeService = policyTypeService;
    }

    public async Task<PolicyType> Handle(GetPolicyTypeQuery request, CancellationToken cancellationToken)
    {
        return await _policyTypeService.GetPolicyTypeAsync(request.PolicyTypeId);
    }
}