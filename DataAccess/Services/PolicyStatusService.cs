using Data.DataAccess;
using Data.Models;
using Data.Services.Interfaces;
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

    public async Task<List<PolicyStatus>> GetAllPolicyStatusesAsync()
    {
        return await _dataContext.PolicyStatuses.ToListAsync();
    }

    public async Task<bool> InsertPolicyStatusAsync(PolicyStatus policyStatus)
    {
        _dataContext.PolicyStatuses.Add(policyStatus);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdatePolicyStatusAsync(PolicyStatus policyStatus)
    {
        _dataContext.PolicyStatuses.Update(policyStatus);
        var result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}