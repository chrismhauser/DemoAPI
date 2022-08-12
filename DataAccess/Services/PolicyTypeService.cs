using Data.DataAccess;
using Data.Models;
using Data.Services.Interfaces;
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

    public async Task<List<PolicyType>> GetAllPolicyTypesAsync()
    {
        return await _dataContext.PolicyTypes.ToListAsync();
    }

    public async Task<bool> InsertPolicyTypeAsync(PolicyType policyType)
    {
        _dataContext.PolicyTypes.Add(policyType);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdatePolicyTypeAsync(PolicyType policyType)
    {
        _dataContext.PolicyTypes.Update(policyType);
        var result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}