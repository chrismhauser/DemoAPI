﻿using Data.DataAccess;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class PaymentTermService : IPaymentTermService
{
    private readonly DataContext _dataContext;

    public PaymentTermService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PaymentTerm> GetPaymentTermAsync(int paymentTermId)
    {
        return await _dataContext.PaymentTerms.SingleOrDefaultAsync(x => x.PaymentTermId == paymentTermId);
    }

    public async Task<bool> InsertPaymentTermAsync(PaymentTerm paymentTerm)
    {
        _dataContext.PaymentTerms.Add(paymentTerm);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}