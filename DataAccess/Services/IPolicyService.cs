using Data.Models;

namespace Data.Services;

public interface IPolicyService
{
    Task<Policy> GetPolicyAsync(int policyId);
    Task<bool> InsertPolicyAsync(Policy policy);
}