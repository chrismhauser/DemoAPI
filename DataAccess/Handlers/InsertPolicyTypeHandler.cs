using Data.Commands;
using Data.Models;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class InsertPolicyTypeHandler : IRequestHandler<InsertPolicyTypeCommand, bool>
{
    private readonly IPolicyTypeService _policyTypeService;

    public InsertPolicyTypeHandler(IPolicyTypeService policyTypeService)
    {
        _policyTypeService = policyTypeService;
    }

    public Task<bool> Handle(InsertPolicyTypeCommand request, CancellationToken cancellationToken)
    {
        return _policyTypeService.InsertPolicyTypeAsync(new PolicyType { PolicyTypeName = request.PolicyType });
    }
}