using Data.Models;

namespace Data.Services.Interfaces;

public interface IPolicyStatusService
{
    Task<PolicyStatus> GetPolicyStatusAsync(int policyStatusId);
    Task<List<PolicyStatus>> GetAllPolicyStatusesAsync();
    Task<bool> InsertPolicyStatusAsync(PolicyStatus policyStatus);
    Task<bool> UpdatePolicyStatusAsync(PolicyStatus policyStatus);
}