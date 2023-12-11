using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumbers;
using Registery.Application.ComandAndQuery.Forms.Commands.AddForm;
using Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm;
using Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForms;
using Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.DeleteOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization;
using Registery.Application.ComandAndQuery.Organizations.Commands.DeleteOrganization;
using Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization;
using Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganization;
using Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganizations;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.AddRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.DeleteRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.UpdateRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Mapping.FormDTO;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Mapping.RosreestrStatusDTO;

namespace Registery.Application.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            return services
                .AddScoped<IRequestHandler<GetDistrictNumberByIdQuery, DistrictNumberDto>, GetDistrictNumberByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetDistrictNumbersQuery, List<DistrictNumberDto>>, GetDistrictNambersQueryHandler>()
                .AddScoped<IRequestHandler<AddFormCommand, FormDto>, AddFormCommandHandler>()
                .AddScoped<IRequestHandler<DeleteFormCommand, Unit>, DeleteFormCommandHandler>()
                .AddScoped<IRequestHandler<UpdateFormCommand, FormDto>, UpdateFormCommandHandler>()
                .AddScoped<IRequestHandler<GetFormByIdQuery, FormDto>, GetFormByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetFormsQuery, List<FormDto>>, GetFormsQueryHandler>()
                .AddScoped<IRequestHandler<AddOMSStatusCommand, OMSStatusDto>, AddOMSStatusCommandHandler>()
                .AddScoped<IRequestHandler<DeleteOMSStatusCommand, Unit>, DeleteOMSStatusCommandHandler>()
                .AddScoped<IRequestHandler<UpdateOMSStatusCommand, OMSStatusDto>, UpdateOMSStatusCommandHandler>()
                .AddScoped<IRequestHandler<GetOMSStatusByIdQuery, OMSStatusDto>, GetOMSStatusByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetOMSStatusesQuery, List<OMSStatusDto>>, GetOMSStatusesQueryHandler>()
                .AddScoped<IRequestHandler<AddOrganizationCommand, OrganizationDto>, AddOrganizationCommandHandler>()
                .AddScoped<IRequestHandler<DeleteOrganizationCommand, Unit>, DeleteOrganizationCommandHandler>()
                .AddScoped<IRequestHandler<UpdateOrganizationCommand, OrganizationDto>, UpdateOrganizationCommandHandler>()
                .AddScoped<IRequestHandler<GetOrganizationByIdQuery, OrganizationDto>, GetOrganizationByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetOrganizationsQuery, List<OrganizationDto>>, GetOrganizationsQueryHandler>()
                .AddScoped<IRequestHandler<AddRosreestrStatusCommand, RosreestrStatusDto>, AddRosreestrStatusCommandHandler>()
                .AddScoped<IRequestHandler<DeleteRosreestrStatusCommand, Unit>, DeleteRosreestrStatusCommandHandler>()
                .AddScoped<IRequestHandler<UpdateRosreestrStatusCommand, RosreestrStatusDto>, UpdateRosreestrStatusCommandHandler>()
                .AddScoped<IRequestHandler<GetRosreestrStatusByIdQuery, RosreestrStatusDto>, GetRosreestrStatusByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetRosreestrStatusesQuery, List<RosreestrStatusDto>>, GetRosreestrStatusesQueryHandler>()
                .AddScoped<IRequestHandler<AddDistrictNumberCommand, DistrictNumberDto>, AddDistrictNumberCommandHandler>()
                .AddScoped<IRequestHandler<DeleteDistrictNumberCommand, Unit>, DeleteDistrictNumberCommandHandler>()
                .AddScoped<IRequestHandler<UpdateDistrictNumberCommand, DistrictNumberDto>, UpdateDistrictNumberCommandHandler>();
        }
    }
}
