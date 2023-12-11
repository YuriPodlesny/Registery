using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.Mapping.OrganizationDTO
{
    public class OrganizationDto : IComparable
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string INN { get; set; }
        public bool Delete { get; set; } = false;
        public DistrictNumberDto? DistrictNumber { get; set; }
        public int CompareTo(object? obj)
        {
            if ((obj == null) || (!(obj is OrganizationDto)))
                return 0;
            else
                return string.Compare(Name, ((OrganizationDto)obj).Name);
        }
    }
}
