using Data.DataAccess;
using Data.Models;
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

    public async Task<bool> InsertCarrierAsync(Carrier carrier)
    {
        _dataContext.Carriers.Add(carrier);
        int result = await _dataContext.SaveChangesAsync();
        return result > 0;
    }
}