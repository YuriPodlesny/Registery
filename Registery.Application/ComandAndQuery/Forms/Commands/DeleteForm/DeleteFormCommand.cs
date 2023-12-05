using MediatR;
using Registery.Application.Models;

namespace Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm
{
    public record DeleteFormCommand(Guid Id) : IRequest<APIResponse>;
}
