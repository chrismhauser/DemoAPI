using Data.Models;
using MediatR;

namespace Data.Commands;

public record InsertPolicyStatusCommand(string PolicyStatus) : IRequest<bool>;