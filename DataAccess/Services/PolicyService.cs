﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccess;
using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class PolicyService : IPolicyService
{
    private readonly DataContext _dataContext;

    public PolicyService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Policy> GetPolicyAsync(int policyId)
    {
        return await _dataContext.Policies.SingleOrDefaultAsync(x => x.PolicyId == policyId);
    }

    public async Task<List<Policy>> GetAllPoliciesAsync()
    {
        return await _dataContext.Policies.ToListAsync();
    }

    public async Task<bool> InsertPolicyAsync(Policy policy)
    {
        _dataContext.Policies.Add(policy);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdatePolicyAsync(Policy policy)
    {
        _dataContext.Policies.Update(policy);
        var result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}

