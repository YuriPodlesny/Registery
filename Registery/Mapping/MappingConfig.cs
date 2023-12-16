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
using Registery.Models.DistrictNumber;
using Registery.Models.Form;
using Registery.Models.OMSStatuses;
using Registery.Models.Organization;
using Registery.Models.RosreestrStatus;
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
            CreateMap<CreateDistrictNumberVM, AddDistrictNumberCommand>().ReverseMap();
            CreateMap<UpdateDistrictNumberVM, UpdateDistrictNumberCommand>().ReverseMap();
            CreateMap<UpdateDistrictNumberVM, DistrictNumberDto>().ReverseMap();

            CreateMap<OMSStatus, OMSStatusDto>().ReverseMap();
            CreateMap<OMSStatus, AddOMSStatusCommand>().ReverseMap();
            CreateMap<OMSStatus, UpdateOMSStatusCommand>().ReverseMap();
            CreateMap<CreateOMSStatusVM, AddOMSStatusCommand>().ReverseMap();
            CreateMap<UpdateOMSStatusVM, UpdateOMSStatusCommand>().ReverseMap();
            CreateMap<UpdateOMSStatusVM, OMSStatusDto>().ReverseMap();

            CreateMap<RosreestrStatus, RosreestrStatusDto>().ReverseMap();
            CreateMap<RosreestrStatus, AddRosreestrStatusCommand>().ReverseMap();
            CreateMap<RosreestrStatus, UpdateRosreestrStatusCommand>().ReverseMap();
            CreateMap<CreateRosreestrStatusVM, AddRosreestrStatusCommand>().ReverseMap();
            CreateMap<UpdateRosreestrStatusVM, UpdateRosreestrStatusCommand>().ReverseMap();
            CreateMap<UpdateRosreestrStatusVM, RosreestrStatusDto>().ReverseMap();

            CreateMap<Organization, OrganizationDto>().ReverseMap();
            CreateMap<Organization, AddOrganizationCommand>().ReverseMap();
            CreateMap<Organization, UpdateOrganizationCommand>().ReverseMap();
            CreateMap<Organization, OrganizationCreateDto>().ReverseMap();
            CreateMap<CreateOrganizationVM, AddOrganizationCommand>().ReverseMap();
            CreateMap<UpdateOrganizationVM, UpdateOrganizationCommand>().ReverseMap();
            CreateMap<UpdateOrganizationVM, OrganizationDto>().ReverseMap();

            CreateMap<Form, FormDto>().ReverseMap();
            CreateMap<Form, AddFormCommand>().ReverseMap();
            CreateMap<Form, UpdateFormCommand>().ReverseMap();
            CreateMap<Form, FormCreateDto>().ReverseMap();
            CreateMap<CreateFormVM, AddFormCommand>().ReverseMap();
            CreateMap<UpdateFormVM, UpdateFormCommand>().ReverseMap();
            CreateMap<UpdateFormVM, FormDto>().ReverseMap();

            CreateMap<User, RegisterVM>().ReverseMap();
            CreateMap<User, UserVM>()
                .ForMember("OrganizationName", opt => opt.MapFrom(c => c.Organization.Name))
                .ReverseMap();
        }
    }
}
