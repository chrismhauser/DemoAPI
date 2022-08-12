using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyStatus;

public record InsertPolicyStatusCommand(string PolicyStatus) : IRequest<bool>;

public class InsertPolicyStatusHandler : IRequestHandler<InsertPolicyStatusCommand, bool>
{
    private readonly IPolicyStatusService _policyStatusService;

    public InsertPolicyStatusHandler(IPolicyStatusService policyStatusService)
    {
        _policyStatusService = policyStatusService;
    }

    public async Task<bool> Handle(InsertPolicyStatusCommand request, CancellationToken cancellationToken)
    {
        return await _policyStatusService.InsertPolicyStatusAsync(new PolicyStatus { PolicyStatusName = request.PolicyStatus });
    }
}