using Registry.Domain.Entities.Base;

namespace Registry.Domain.Entities
{
    public class Form : BaseEntity
    {
        public string? CadastralNumber { get; set; }
        public string? Address { get; set; }
        public string? StatusEGRN { get; set; }
        public DateTime LastModifiedDateRosreestr { get; set; }
        public DateTime LastModifiedDateOMS { get; set; }
        public string? LastModifiedUserOMS { get; set; }


        public Guid? DistrictNumberId { get; set; }
        public DistrictNumber? DistrictNumber { get; set; }

        public Guid? RosreestrStatusId { get; set; }
        public RosreestrStatus? RosreestrStatus { get; set; }

        public Guid? OMSStatusId { get; set; }
        public OMSStatus? OMSStatus { get; set; }
    }
}
