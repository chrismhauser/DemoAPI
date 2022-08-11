using Data.Commands;
using Data.Models;
using Data.Queries;
using Data.Services;
using MediatR;

namespace Data.Handlers;

public class InsertCarrierHandler : IRequestHandler<InsertCarrierCommand, bool>
{
    private readonly ICarrierService _carrierService;

    public InsertCarrierHandler(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }

    public Task<bool> Handle(InsertCarrierCommand request, CancellationToken cancellationToken)
    {
        return _carrierService.InsertCarrierAsync(new Carrier {CarrierName = request.CarrierName});
    }
}