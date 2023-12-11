using MediatR;
using Registery.Application.Mapping.FormDTO;

namespace Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm
{
    public class UpdateFormCommand : IRequest<FormDto>
    {
        public Guid Id { get; set; }
        public string? CadastralNumber { get; set; }
        public string? Address { get; set; }
        public string? StatusEGRN { get; set; }
        public DateTime LastModifiedDateRosreestr { get; set; }
        public DateTime LastModifiedDateOMS { get; set; }
        public string? LastModifiedUserOMS { get; set; }


        public Guid? DistrictNumberId { get; set; }
        public Guid? RosreestrStatusId { get; set; }
        public Guid? OMSStatusId { get; set; }
    }
}
