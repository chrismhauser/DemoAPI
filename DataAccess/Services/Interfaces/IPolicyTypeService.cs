using Data.Models;

namespace Data.Services.Interfaces;

public interface IPolicyTypeService
{
    Task<PolicyType> GetPolicyTypeAsync(int policyTypeId);
    Task<List<PolicyType>> GetAllPolicyTypesAsync();
    Task<bool> InsertPolicyTypeAsync(PolicyType policyType);
    Task<bool> UpdatePolicyTypeAsync(PolicyType policyType);
}