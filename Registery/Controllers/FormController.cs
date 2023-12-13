using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.ComandAndQuery.Forms.Commands.AddForm;
using Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForms;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses;
using Registery.Models.Form;

namespace Registery.Controllers
{
    public class FormController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FormController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            var form = await _mediator.Send(new GetFormsQuery(), CancellationToken.None);
            //organization.Sort();
            return View(form);
        }

        [HttpGet]
        public async Task<IActionResult> CreateForm()
        {
            var selectorDistrictNumbers = new Dictionary<Guid, string>();
            var selectorRosreestrStatus = new Dictionary<Guid, string>();
            var seleсtorOMSStatus = new Dictionary<Guid, string>();

            var districtNumbers = await _mediator.Send(new GetDistrictNumbersQuery(), CancellationToken.None);
            var rosreestrStatus = await _mediator.Send(new GetRosreestrStatusesQuery(), CancellationToken.None);
            var omsStatus = await _mediator.Send(new GetOMSStatusesQuery(), CancellationToken.None);

            districtNumbers.ForEach(e => selectorDistrictNumbers.Add(e.Id, e.Value!));
            rosreestrStatus.ForEach(e => selectorRosreestrStatus.Add(e.Id, e.Value!));
            omsStatus.ForEach(e => seleсtorOMSStatus.Add(e.Id, e.Value!));

            ViewBag.SelectListDistrictNumbers = selectorDistrictNumbers;
            ViewBag.SelectListRosreestrStatus = selectorRosreestrStatus;
            ViewBag.SelectOMSStatus = seleсtorOMSStatus;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm(CreateFormVM model)
        {
            if (!ModelState.IsValid) { return View(); }

            var addModel = _mapper.Map<AddFormCommand>(model);
            await _mediator.Send(addModel, CancellationToken.None);

            return RedirectToAction(nameof(GetForms), "Form");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateForm(Guid id)
        {
            var selectorDistrictNumbers = new Dictionary<Guid, string>();
            var selectorRosreestrStatus = new Dictionary<Guid, string>();
            var seleсtorOMSStatus = new Dictionary<Guid, string>();

            var districtNumbers = await _mediator.Send(new GetDistrictNumbersQuery(), CancellationToken.None);
            var rosreestrStatus = await _mediator.Send(new GetRosreestrStatusesQuery(), CancellationToken.None);
            var omsStatus = await _mediator.Send(new GetOMSStatusesQuery(), CancellationToken.None);

            districtNumbers.ForEach(e => selectorDistrictNumbers.Add(e.Id, e.Value!));
            rosreestrStatus.ForEach(e => selectorRosreestrStatus.Add(e.Id, e.Value!));
            omsStatus.ForEach(e => seleсtorOMSStatus.Add(e.Id, e.Value!));

            ViewBag.SelectListDistrictNumbers = selectorDistrictNumbers;
            ViewBag.SelectListRosreestrStatus = selectorRosreestrStatus;
            ViewBag.SelectOMSStatus = seleсtorOMSStatus;

            var result = _mediator.Send(new GetFormByIdQuery(id), CancellationToken.None);
            var updateModel = _mapper.Map<UpdateFormVM>(result);

            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateForm(UpdateFormVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            await _mediator.Send(_mapper.Map<UpdateOrganizationCommand>(model));
            return RedirectToAction(nameof(GetForms), "Form");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteForm(Guid id)
        {
            await _mediator.Send(new DeleteFormCommand(id), CancellationToken.None);
            return RedirectToAction(nameof(GetForms), "Form");
        }
    }
}
