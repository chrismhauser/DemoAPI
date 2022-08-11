using Data.Models;

namespace Data.Services;

public interface IPolicyTypeService
{
    Task<PolicyType> GetPolicyTypeAsync(int policyTypeId);
    Task<bool> InsertPolicyTypeAsync(PolicyType policyType);
}