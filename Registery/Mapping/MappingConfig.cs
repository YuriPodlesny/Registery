using AutoMapper;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber;
using Registery.Application.ComandAndQuery.Forms.Commands.AddForm;
using Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus;
using Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization;
using Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.AddRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.UpdateRosreestrStatus;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Mapping.FormDTO;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Domain.Entities;
using Registery.Models.Account;
using Registry.Domain.Entities;

namespace Registery.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<DistrictNumber, DistrictNumberDto>().ReverseMap();
            CreateMap<DistrictNumber, AddDistrictNumberCommand>().ReverseMap();
            CreateMap<DistrictNumber, UpdateDistrictNumberCommand>().ReverseMap();

            CreateMap<OMSStatus, OMSStatusDto>().ReverseMap();
            CreateMap<OMSStatus, AddOMSStatusCommand>().ReverseMap();
            CreateMap<OMSStatus, UpdateOMSStatusCommand>().ReverseMap();

            CreateMap<RosreestrStatus, RosreestrStatusDto>().ReverseMap();
            CreateMap<RosreestrStatus, AddRosreestrStatusCommand>().ReverseMap();
            CreateMap<RosreestrStatus, UpdateRosreestrStatusCommand>().ReverseMap();

            CreateMap<Organization, OrganizationDto>().ReverseMap();
            CreateMap<Organization, AddOrganizationCommand>().ReverseMap();
            CreateMap<Organization, UpdateOrganizationCommand>().ReverseMap();
            CreateMap<Organization, OrganizationCreateDto>().ReverseMap();

            CreateMap<Form, FormDto>().ReverseMap();
            CreateMap<Form, AddFormCommand>().ReverseMap();
            CreateMap<Form, UpdateFormCommand>().ReverseMap();
            CreateMap<Form, FormCreateDto>().ReverseMap();

            CreateMap<User, RegisterVM>().ReverseMap();
        }
    }
}
