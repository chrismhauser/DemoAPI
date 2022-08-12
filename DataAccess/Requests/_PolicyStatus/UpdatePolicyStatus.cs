using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyStatus;

public record UpdatePolicyStatusCommand(int PolicyStatusId, string PolicyStatus) : IRequest<bool>;

public class UpdatePolicyStatusHandler : IRequestHandler<UpdatePolicyStatusCommand, bool>
{
    private readonly IPolicyStatusService _policyStatusService;

    public UpdatePolicyStatusHandler(IPolicyStatusService policyStatusService)
    {
        _policyStatusService = policyStatusService;
    }

    public async Task<bool> Handle(UpdatePolicyStatusCommand request, CancellationToken cancellationToken)
    {
        var policyStatus = await _policyStatusService.GetPolicyStatusAsync(request.PolicyStatusId);
        if (policyStatus is null) return false;

        policyStatus.PolicyStatusName = request.PolicyStatus;

        return await _policyStatusService.UpdatePolicyStatusAsync(policyStatus);
    }
}