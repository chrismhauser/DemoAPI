using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Policy;

public record GetAllPoliciesQuery() : IRequest<List<Policy>>;

public class GetAllPoliciesHandler : IRequestHandler<GetAllPoliciesQuery, List<Policy>>
{
    private readonly IPolicyService _policyService;

    public GetAllPoliciesHandler(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    public async Task<List<Policy>> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
    {
        return await _policyService.GetAllPoliciesAsync();
    }
}