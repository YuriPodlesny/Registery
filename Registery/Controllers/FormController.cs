using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.ComandAndQuery.Forms.Commands.AddForm;
using Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm;
using Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForms;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses;
using Registery.Application.Mapping.FormDTO;
using Registery.Domain.Entities;
using Registery.Models;
using Registery.Models.Form;

namespace Registery.Controllers
{
    public class FormController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public FormController(IMediator mediator, IMapper mapper, UserManager<User> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetForms(int pageSize = 10, int pageNumber = 1)
        {
            var form = await _mediator.Send(new GetFormsQuery(pageSize, pageNumber), CancellationToken.None);

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

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("Росреестр"))
            {
                addModel.LastModifiedDateRosreestr = DateTime.UtcNow;
            }
            if (User.IsInRole("ОМС"))
            {
                addModel.LastModifiedDateOMS = DateTime.UtcNow;
                addModel.LastModifiedUserOMS = user?.LastName + " " + user?.FirstName + " " + user?.MiddleName;
            }

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

            var result = await _mediator.Send(new GetFormByIdQuery(id), CancellationToken.None);
            var updateModel = _mapper.Map<UpdateFormVM>(result);

            if (User.IsInRole("ОМС"))
            {
                return View("UpdateFormOMS", updateModel);
            }
            if (User.IsInRole("Росреестр"))
            {
                return View("UpdateFormRosreestr", updateModel);
            }

            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateForm(UpdateFormVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var addModel = _mapper.Map<UpdateFormCommand>(model);

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (User.IsInRole("Росреестр"))
            {
                addModel.LastModifiedDateRosreestr = DateTime.UtcNow;
            }
            if (User.IsInRole("ОМС"))
            {
                addModel.LastModifiedDateOMS = DateTime.UtcNow;
                addModel.LastModifiedUserOMS = user?.LastName + " " + user?.FirstName + " " + user?.MiddleName;
            }
            await _mediator.Send(addModel);
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
