using System.Reflection.Metadata.Ecma335;
using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Carrier;

public record UpdateCarrierCommand(int CarrierId, string CarrierName) : IRequest<bool>;

public class UpdateCarrierHandler : IRequestHandler<UpdateCarrierCommand, bool>
{
    private readonly ICarrierService _carrierService;

    public UpdateCarrierHandler(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    public async Task<bool> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
    {
        var carrier = await _carrierService.GetCarrierAsync(request.CarrierId);

        if (carrier is null) return false;

        carrier.CarrierName = request.CarrierName;

        return await _carrierService.UpdateCarrierAsync(carrier);
    }
}