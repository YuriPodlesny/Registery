using MediatR;

namespace Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm
{
    public record DeleteFormCommand(Guid Id) : IRequest<Unit>;
}
