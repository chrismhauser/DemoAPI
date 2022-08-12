using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Policy;

public record GetPolicyQuery(int PolicyId) : IRequest<Policy>;

public class GetPolicyHandler : IRequestHandler<GetPolicyQuery, Policy>
{
    private readonly IPolicyService _policyService;

    public GetPolicyHandler(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    public async Task<Policy> Handle(GetPolicyQuery request, CancellationToken cancellationToken)
    {
        return await _policyService.GetPolicyAsync(request.PolicyId);
    }
}