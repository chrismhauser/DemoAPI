using Data.Models;
using Data.Services.Interfaces;
using MediatR;

namespace Data.Requests._Carrier;

public record GetAllCarriersQuery() : IRequest<List<Carrier>>;

public class GetAllCarriersHandler : IRequestHandler<GetAllCarriersQuery, List<Carrier>>
{
    private readonly ICarrierService _carrierService;

    public GetAllCarriersHandler(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    public async Task<List<Carrier>> Handle(GetAllCarriersQuery request, CancellationToken cancellationToken)
    {
        return await _carrierService.GetAllCarriersAsync();
    }
}