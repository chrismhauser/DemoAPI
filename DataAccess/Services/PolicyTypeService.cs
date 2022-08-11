using Data.DataAccess;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class PolicyTypeService : IPolicyTypeService
{
    private readonly DataContext _dataContext;

    public PolicyTypeService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PolicyType> GetPolicyTypeAsync(int policyTypeId)
    {
        return await _dataContext.PolicyTypes.SingleOrDefaultAsync(x => x.PolicyTypeId == policyTypeId);
    }

    public async Task<bool> InsertPolicyTypeAsync(PolicyType policyType)
    {
        _dataContext.PolicyTypes.Add(policyType);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}