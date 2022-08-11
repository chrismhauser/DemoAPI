using Data.Models;
using Data.Queries;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class GetPolicyStatusHandler : IRequestHandler<GetPolicyStatusQuery, PolicyStatus>
{
    private readonly IPolicyStatusService _policyStatusService;

    public GetPolicyStatusHandler(IPolicyStatusService policyStatusService)
    {
        _policyStatusService = policyStatusService;
    }

    public Task<PolicyStatus> Handle(GetPolicyStatusQuery request, CancellationToken cancellationToken)
    {
        return _policyStatusService.GetPolicyStatusAsync(request.PolicyStatusId);
    }
}