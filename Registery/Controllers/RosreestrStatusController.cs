using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber;
using Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.AddRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.DeleteRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.UpdateRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses;
using Registery.Models.DistrictNumber;
using Registery.Models.RosreestrStatus;

namespace Registery.Controllers
{
    public class RosreestrStatusController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RosreestrStatusController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRosreestrStatus()
        {
            var omsStatus = await _mediator.Send(new GetRosreestrStatusesQuery(), CancellationToken.None);
            omsStatus.Sort();
            return View(omsStatus);
        }

        [HttpGet]
        public IActionResult CreateOMSStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRosreestrStatus(CreateDistrictNumberVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var addModel = _mapper.Map<AddRosreestrStatusCommand>(model);
            await _mediator.Send(addModel, CancellationToken.None);

            return RedirectToAction(nameof(GetRosreestrStatus), "RosreestrStatus");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRosreestrStatus(Guid id)
        {
            var result = await _mediator.Send(new GetDistrictNumberByIdQuery(id), CancellationToken.None);
            var updateModel = _mapper.Map<UpdateRosreestrStatusVM>(result);
            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRosreestrStatus(UpdateDistrictNumberVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var updateModel = _mapper.Map<UpdateRosreestrStatusCommand>(model);
            await _mediator.Send(updateModel, CancellationToken.None);

            return RedirectToAction(nameof(GetRosreestrStatus), "RosreestrStatus");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRosreestrStatus(Guid id)
        {
            await _mediator.Send(new DeleteRosreestrStatusCommand(id), CancellationToken.None);
            return RedirectToAction(nameof(GetRosreestrStatus), "RosreestrStatus");
        }
    }
}
