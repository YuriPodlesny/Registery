using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Models.DistrictNumber;

namespace Registery.Controllers
{
    public class DistrictNumberController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DistrictNumberController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDistrictNumbers()
        {
            var districtNumbers = await _mediator.Send(new GetDistrictNumbersQuery(), CancellationToken.None);
            districtNumbers.Sort();
            return View(districtNumbers);
        }

        [HttpGet]
        public IActionResult CreateDistrictNumber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistrictNumber(CreateDistrictNumberVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var addModel = _mapper.Map<AddDistrictNumberCommand>(model);
            await _mediator.Send(addModel, CancellationToken.None);

            return RedirectToAction(nameof(GetDistrictNumbers), "DistrictNumber");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDistrictNumber(Guid id)
        {
            var result = await _mediator.Send(new GetDistrictNumberByIdQuery(id), CancellationToken.None);
            var updateModel = _mapper.Map<UpdateDistrictNumberVM>(result);
            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDistrictNumber(UpdateDistrictNumberVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var updateModel = _mapper.Map<UpdateDistrictNumberCommand>(model);
            await _mediator.Send(updateModel, CancellationToken.None);

            return RedirectToAction(nameof(GetDistrictNumbers), "DistrictNumber");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDistrictNumber(Guid id)
        {
            await _mediator.Send(new DeleteDistrictNumberCommand(id), CancellationToken.None);
            return RedirectToAction(nameof(GetDistrictNumbers), "DistrictNumber");
        }
    }
}
