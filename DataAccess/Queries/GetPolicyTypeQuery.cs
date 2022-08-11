using Data.Models;
using MediatR;

namespace Data.Queries;

public record GetPolicyTypeQuery(int PolicyTypeId) : IRequest<PolicyType>;