using Data.Models;

namespace Data.Services;

public interface ICarrierService
{
    Task<Carrier> GetCarrierAsync(int carrierId);
    Task<bool> InsertCarrierAsync(Carrier carrier);
}