using Data.Models;

namespace Data.Services.Interfaces;

public interface ICarrierService
{
    Task<Carrier> GetCarrierAsync(int carrierId);
    Task<List<Carrier>> GetAllCarriersAsync();
    Task<bool> InsertCarrierAsync(Carrier carrier);
    Task<bool> UpdateCarrierAsync(Carrier carrier);
}