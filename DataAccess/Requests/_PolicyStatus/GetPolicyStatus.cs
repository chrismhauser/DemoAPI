using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyStatus;

public record GetPolicyStatusQuery(int PolicyStatusId) : IRequest<PolicyStatus>;

public class GetPolicyStatusHandler : IRequestHandler<GetPolicyStatusQuery, PolicyStatus>
{
    private readonly IPolicyStatusService _policyStatusService;

    public GetPolicyStatusHandler(IPolicyStatusService policyStatusService)
    {
        _policyStatusService = policyStatusService;
    }

    public async Task<PolicyStatus> Handle(GetPolicyStatusQuery request, CancellationToken cancellationToken)
    {
        return await _policyStatusService.GetPolicyStatusAsync(request.PolicyStatusId);
    }
}