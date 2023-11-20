namespace Registery.Application.Mapping.OrganizationDTO
{
    public class OrganizationCreateDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? INN { get; set; }
        public Guid DistrictNumberId { get; set; }
    }
}
