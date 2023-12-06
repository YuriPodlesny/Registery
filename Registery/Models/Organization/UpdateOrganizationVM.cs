namespace Registery.Models.Organization
{
    public class UpdateOrganizationVM
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string INN { get; set; }

        public Guid DistrictNumberId { get; set; }
    }
}
