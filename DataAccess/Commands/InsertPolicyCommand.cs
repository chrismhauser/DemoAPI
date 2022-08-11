using Data.Models;
using MediatR;

namespace Data.Commands;

public record InsertPolicyCommand(
    string PolicyNumber,
    DateTime EffectiveDate,
    int PolicyTypeId,
    int PolicyStatusId,
    int CarrierId,
    int PaymentTermId
) : IRequest<bool>;