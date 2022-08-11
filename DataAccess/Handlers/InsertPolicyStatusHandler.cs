using Data.Commands;
using Data.Models;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class InsertPolicyStatusHandler : IRequestHandler<InsertPolicyStatusCommand, bool>
{
    private readonly IPolicyStatusService _policyStatusService;

    public InsertPolicyStatusHandler(IPolicyStatusService policyStatusService)
    {
        _policyStatusService = policyStatusService;
    }

    public Task<bool> Handle(InsertPolicyStatusCommand request, CancellationToken cancellationToken)
    {
        return _policyStatusService.InsertPolicyStatusAsync(new PolicyStatus { PolicyStatusName = request.PolicyStatus });
    }
}