using MediatR;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.DeleteOrganization
{
    public record DeleteOrganizationCommand(Guid Id) : IRequest<Unit>;

}
