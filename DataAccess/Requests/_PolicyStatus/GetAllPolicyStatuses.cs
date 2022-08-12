using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyStatus;

public record GetAllPolicyStatusesQuery() : IRequest<List<PolicyStatus>>;

public class GetAllPolicyStatusesHandler : IRequestHandler<GetAllPolicyStatusesQuery, List<PolicyStatus>>
{
    private readonly IPolicyStatusService _policyStatusService;

    public GetAllPolicyStatusesHandler(IPolicyStatusService policyStatusService)
    {
        _policyStatusService = policyStatusService;
    }

    public async Task<List<PolicyStatus>> Handle(GetAllPolicyStatusesQuery request, CancellationToken cancellationToken)
    {
        return await _policyStatusService.GetAllPolicyStatusesAsync();
    }
}