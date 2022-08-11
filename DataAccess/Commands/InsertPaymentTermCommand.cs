using Data.Models;
using MediatR;

namespace Data.Commands;

public record InsertPaymentTermCommand(string PaymentTerm) : IRequest<bool>;