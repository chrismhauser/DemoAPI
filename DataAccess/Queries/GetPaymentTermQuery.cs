using Data.Models;
using MediatR;

namespace Data.Queries;

public record GetPaymentTermQuery(int PaymentTermId) : IRequest<PaymentTerm>;