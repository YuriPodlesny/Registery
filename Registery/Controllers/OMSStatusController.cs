using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber;
using Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Models.DistrictNumber;
using Registery.Models.OMSStatuses;

namespace Registery.Controllers
{
    public class OMSStatusController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OMSStatusController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOMSStatuses()
        {
            var omsStatus = await _mediator.Send(new GetOMSStatusesQuery(), CancellationToken.None);
            omsStatus.Sort();
            return View(omsStatus);
        }

        [HttpGet]
        public IActionResult CreateOMSStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOMSStatus(CreateOMSStatusVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var addModel = _mapper.Map<AddOMSStatusCommand>(model);
            await _mediator.Send(addModel, CancellationToken.None);

            return RedirectToAction(nameof(GetOMSStatuses), "OMSStatus");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOMSStatus(Guid id)
        {
            var result = await _mediator.Send(new GetOMSStatusByIdQuery(id), CancellationToken.None);
            var updateModel = _mapper.Map<UpdateDistrictNumberVM>(result);
            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOMSStatus(UpdateOMSStatusVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var updateModel = _mapper.Map<UpdateOMSStatusCommand>(model);
            await _mediator.Send(updateModel, CancellationToken.None);

            return RedirectToAction(nameof(GetOMSStatuses), "OMSStatus");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDistrictNumber(Guid id)
        {
            await _mediator.Send(new DeleteDistrictNumberCommand(id), CancellationToken.None);
            return RedirectToAction(nameof(GetOMSStatuses), "OMSStatus");
        }
    }
}
