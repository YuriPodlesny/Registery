using MediatR;
using Registery.Application.Mapping.OrganizationDTO;

namespace Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganization
{
    public record GetOrganizationByIdQuery(Guid Id) : IRequest<OrganizationDto>;

}
