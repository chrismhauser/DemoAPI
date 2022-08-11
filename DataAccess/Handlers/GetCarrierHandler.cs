using Data.Models;
using Data.Queries;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class GetCarrierHandler: IRequestHandler<GetCarrierQuery, Carrier>
{
    private readonly ICarrierService _carrierService;

    public GetCarrierHandler(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    public Task<Carrier> Handle(GetCarrierQuery request, CancellationToken cancellationToken)
    {
        return _carrierService.GetCarrierAsync(request.CarrierId);
    }
}