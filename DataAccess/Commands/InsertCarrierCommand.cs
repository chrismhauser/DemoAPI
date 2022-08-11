using Data.Models;
using MediatR;

namespace Data.Commands;

public record InsertCarrierCommand(string CarrierName) : IRequest<bool>;