using Data.DataAccess;
using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class CarrierService : ICarrierService
{
    private readonly DataContext _dataContext;

    public CarrierService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Carrier> GetCarrierAsync(int carrierId)
    {
        return await _dataContext.Carriers.SingleOrDefaultAsync(x => x.CarrierId == carrierId);
    }

    public async Task<List<Carrier>> GetAllCarriersAsync()
    {
        return await _dataContext.Carriers.ToListAsync();
    }

    public async Task<bool> InsertCarrierAsync(Carrier carrier)
    {
        _dataContext.Carriers.Add(carrier);
        var result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateCarrierAsync(Carrier carrier)
    {
        _dataContext.Carriers.Update(carrier);
        var result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}