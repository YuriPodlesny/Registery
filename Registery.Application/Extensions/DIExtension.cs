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
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;

namespace Registery.Application.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            return services
                .AddScoped<IRequestHandler<GetDistrictNumberByIdQuery, DistrictNumberDto>, GetDistrictNumberByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetDistrictNumbersQuery, List<DistrictNumberDto>>, GetDistrictNambersQueryHandler>()
                .AddScoped<IRequestHandler<AddFormCommand, APIResponse>, AddFormCommandHandler>()
                .AddScoped<IRequestHandler<DeleteFormCommand, APIResponse>, DeleteFormCommandHandler>()
                .AddScoped<IRequestHandler<UpdateFormCommand, APIResponse>, UpdateFormCommandHandler>()
                .AddScoped<IRequestHandler<GetFormByIdQuery, APIResponse>, GetFormByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetFormsQuery, APIResponse>, GetFormsQueryHandler>()
                .AddScoped<IRequestHandler<AddOMSStatusCommand, OMSStatusDto>, AddOMSStatusCommandHandler>()
                .AddScoped<IRequestHandler<DeleteOMSStatusCommand, Unit>, DeleteOMSStatusCommandHandler>()
                .AddScoped<IRequestHandler<UpdateOMSStatusCommand, OMSStatusDto>, UpdateOMSStatusCommandHandler>()
                .AddScoped<IRequestHandler<GetOMSStatusByIdQuery, APIResponse>, GetOMSStatusByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetOMSStatusesQuery, List<OMSStatusDto>>, GetOMSStatusesQueryHandler>()
                .AddScoped<IRequestHandler<AddOrganizationCommand, APIResponse>, AddOrganizationCommandHandler>()
                .AddScoped<IRequestHandler<DeleteOrganizationCommand, APIResponse>, DeleteOrganizationCommandHandler>()
                .AddScoped<IRequestHandler<UpdateOrganizationCommand, APIResponse>, UpdateOrganizationCommandHandler>()
                .AddScoped<IRequestHandler<GetOrganizationByIdQuery, APIResponse>, GetOrganizationByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetOrganizationsQuery, List<Organization>>, GetOrganizationsQueryHandler>()
                .AddScoped<IRequestHandler<AddRosreestrStatusCommand, APIResponse>, AddRosreestrStatusCommandHandler>()
                .AddScoped<IRequestHandler<DeleteRosreestrStatusCommand, APIResponse>, DeleteRosreestrStatusCommandHandler>()
                .AddScoped<IRequestHandler<UpdateRosreestrStatusCommand, APIResponse>, UpdateRosreestrStatusCommandHandler>()
                .AddScoped<IRequestHandler<GetRosreestrStatusByIdQuery, APIResponse>, GetRosreestrStatusByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetRosreestrStatusesQuery, APIResponse>, GetRosreestrStatusesQueryHandler>()
                .AddScoped<IRequestHandler<AddDistrictNumberCommand, DistrictNumberDto>, AddDistrictNumberCommandHandler>()
                .AddScoped<IRequestHandler<DeleteDistrictNumberCommand, Unit>, DeleteDistrictNumberCommandHandler>()
                .AddScoped<IRequestHandler<UpdateDistrictNumberCommand, DistrictNumberDto>, UpdateDistrictNumberCommandHandler>();
        }
    }
}
