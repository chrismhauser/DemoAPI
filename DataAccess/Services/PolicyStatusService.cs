using Data.DataAccess;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class PolicyStatusService : IPolicyStatusService
{
    private readonly DataContext _dataContext;

    public PolicyStatusService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PolicyStatus> GetPolicyStatusAsync(int policyStatusId)
    {
        return await _dataContext.PolicyStatuses.SingleOrDefaultAsync(x => x.PolicyStatusId == policyStatusId);
    }

    public async Task<bool> InsertPolicyStatusAsync(PolicyStatus policyStatus)
    {
        _dataContext.PolicyStatuses.Add(policyStatus);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}