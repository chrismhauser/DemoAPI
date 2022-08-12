using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Carrier;

public record InsertCarrierCommand(string CarrierName) : IRequest<bool>;

public class InsertCarrierHandler : IRequestHandler<InsertCarrierCommand, bool>
{
    private readonly ICarrierService _carrierService;

    public InsertCarrierHandler(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    public async Task<bool> Handle(InsertCarrierCommand request, CancellationToken cancellationToken)
    {
        return await _carrierService.InsertCarrierAsync(new Carrier { CarrierName = request.CarrierName });
    }
}