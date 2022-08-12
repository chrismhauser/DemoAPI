using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyType;

public record GetAllPolicyTypesQuery() : IRequest<List<PolicyType>>;

public class GetAllPolicyTypesHandler : IRequestHandler<GetAllPolicyTypesQuery, List<PolicyType>>
{
    private readonly IPolicyTypeService _policyTypeService;

    public GetAllPolicyTypesHandler(IPolicyTypeService policyTypeService)
    {
        _policyTypeService = policyTypeService;
    }

    public async Task<List<PolicyType>> Handle(GetAllPolicyTypesQuery request, CancellationToken cancellationToken)
    {
        return await _policyTypeService.GetAllPolicyTypesAsync();
    }
}