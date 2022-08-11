using Data.Models;
using MediatR;

namespace Data.Commands;

public record InsertPolicyTypeCommand(string PolicyType) : IRequest<bool>;