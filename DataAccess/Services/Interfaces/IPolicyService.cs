using Data.Models;

namespace Data.Services.Interfaces;

public interface IPolicyService
{
    Task<Policy> GetPolicyAsync(int policyId);
    Task<List<Policy>> GetAllPoliciesAsync();
    Task<bool> InsertPolicyAsync(Policy policy);
    Task<bool> UpdatePolicyAsync(Policy policy);
}