using MediatR;
using Registery.Application.Mapping.OrganizationDTO;

namespace Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganizations
{
    public record GetOrganizationsQuery : IRequest<List<OrganizationDto>>;
}
