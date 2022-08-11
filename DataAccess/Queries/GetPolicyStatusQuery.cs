using Data.Models;
using MediatR;

namespace Data.Queries;

public record GetPolicyStatusQuery(int PolicyStatusId) : IRequest<PolicyStatus>;