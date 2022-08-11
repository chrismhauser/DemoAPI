using Data.Models;
using MediatR;

namespace Data.Queries;

public record GetPolicyQuery(int PolicyId) : IRequest<Policy>;