using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Carrier;

public record GetCarrierQuery(int CarrierId) : IRequest<Carrier>;

public class GetCarrierHandler : IRequestHandler<GetCarrierQuery, Carrier>
{
    private readonly ICarrierService _carrierService;

    public GetCarrierHandler(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    public async Task<Carrier> Handle(GetCarrierQuery request, CancellationToken cancellationToken)
    {
        return await _carrierService.GetCarrierAsync(request.CarrierId);
    }
}