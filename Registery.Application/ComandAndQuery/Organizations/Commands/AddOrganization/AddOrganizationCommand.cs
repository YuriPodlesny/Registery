using MediatR;
using Registery.Application.Mapping.OrganizationDTO;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization
{
    public class AddOrganizationCommand : IRequest<OrganizationDto>
    {
        public required string Name { get; set; }
        public required string INN { get; set; }
        public Guid DistrictNumberId { get; set; }
    }
}
