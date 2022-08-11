using Data.Models;

namespace Data.Services;

public interface IPolicyStatusService
{
    Task<PolicyStatus> GetPolicyStatusAsync(int policyStatusId);
    Task<bool> InsertPolicyStatusAsync(PolicyStatus policyStatus);
}