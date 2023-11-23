using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
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
            return View(await _mediator.Send(new GetDistrictNumbersQuery(), CancellationToken.None));
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
        public IActionResult UpdateDistrictNumber()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateDistrictNumber(UpdateDistrictNumberVM model)
        {
            if (!ModelState.IsValid) { return View(model); }


        }
    }
}
