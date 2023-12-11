using MediatR;
using Registery.Application.Mapping.OrganizationDTO;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommand : IRequest<OrganizationDto>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string INN { get; set; }
        public Guid DistrictNumberId { get; set; }
    }
}
