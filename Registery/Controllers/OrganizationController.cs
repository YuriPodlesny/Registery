using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber;
using Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization;
using Registery.Application.ComandAndQuery.Organizations.Commands.DeleteOrganization;
using Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization;
using Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganization;
using Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganizations;
using Registery.Models.DistrictNumber;
using Registery.Models.Organization;

namespace Registery.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrganizationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            var organization = await _mediator.Send(new GetOrganizationsQuery(), CancellationToken.None);
            organization.Sort();
            return View(organization);
        }

        [HttpGet]
        public IActionResult CreateOrganization()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization(CreateOrganizationVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var addModel = _mapper.Map<AddOrganizationCommand>(model);
            await _mediator.Send(addModel, CancellationToken.None);

            return RedirectToAction(nameof(GetOrganizations), "Organization");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrganization(Guid id)
        {
            var result = await _mediator.Send(new GetOrganizationByIdQuery(id), CancellationToken.None);
            var updateModel = _mapper.Map<UpdateOrganizationVM>(result);
            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrganization(UpdateOrganizationVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var updateModel = _mapper.Map<UpdateOrganizationCommand>(model);
            await _mediator.Send(updateModel, CancellationToken.None);

            return RedirectToAction(nameof(GetOrganizations), "Organization");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            await _mediator.Send(new DeleteOrganizationCommand(id), CancellationToken.None);
            return RedirectToAction(nameof(GetOrganizations), "Organization");
        }
    }
}
