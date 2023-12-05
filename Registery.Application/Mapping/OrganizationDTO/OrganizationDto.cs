using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.Mapping.OrganizationDTO
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string INN { get; set; }
        public DistrictNumberDto? DistrictNumber { get; set; }
    }
}
