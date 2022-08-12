using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._PolicyType;

public record InsertPolicyTypeCommand(string PolicyType) : IRequest<bool>;

public class InsertPolicyTypeHandler : IRequestHandler<InsertPolicyTypeCommand, bool>
{
    private readonly IPolicyTypeService _policyTypeService;

    public InsertPolicyTypeHandler(IPolicyTypeService policyTypeService)
    {
        _policyTypeService = policyTypeService;
    }

    public async Task<bool> Handle(InsertPolicyTypeCommand request, CancellationToken cancellationToken)
    {
        return await _policyTypeService.InsertPolicyTypeAsync(new PolicyType { PolicyTypeName = request.PolicyType });
    }
}