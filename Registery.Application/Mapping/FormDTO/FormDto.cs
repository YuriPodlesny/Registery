using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.Mapping.FormDTO
{
    public class FormDto
    {
        public Guid Id { get; set; }
        public string? CadastralNumber { get; set; }
        public string? Address { get; set; }
        public string? StatusEGRN { get; set; }
        public DateTime LastModifiedDateRosreestr { get; set; }
        public DateTime LastModifiedDateOMS { get; set; }
        public string? LastModifiedUserOMS { get; set; }


        public DistrictNumberDto? DistrictNumber { get; set; }
        public RosreestrStatusDto? RosreestrStatus { get; set; }
        public OMSStatusDto? OMSStatus { get; set; }
    }
}
