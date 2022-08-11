using Data.Models;
using MediatR;

namespace Data.Queries;

public record GetCarrierQuery(int CarrierId) : IRequest<Carrier>;