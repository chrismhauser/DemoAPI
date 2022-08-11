using Data.DataAccess;
using Data.Models;
using Data.Queries;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class GetPolicyHandler : IRequestHandler<GetPolicyQuery, Policy>
{
    private readonly IPolicyService _policyService;

    public GetPolicyHandler(IPolicyService policyService)
    {
        _policyService = policyService;
    }
    public Task<Policy> Handle(GetPolicyQuery request, CancellationToken cancellationToken)
    {
        return _policyService.GetPolicyAsync(request.PolicyId);
    }
}