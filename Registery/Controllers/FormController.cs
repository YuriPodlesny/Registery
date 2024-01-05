using AutoMapper;
using ClosedXML.Excel;
using ExcelDataReader;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNamberByName;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.ComandAndQuery.Forms.Commands.AddForm;
using Registery.Application.ComandAndQuery.Forms.Commands.DeleteForm;
using Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForm;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForms;
using Registery.Application.ComandAndQuery.Forms.Queries.GetFormsWithPagination;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatus;
using Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatus;
using Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses;
using Registery.Application.Mapping.FormDTO;
using Registery.Domain.Entities;
using Registery.Models.Form;
using Registry.Domain.Entities;
using System.Data;
using System.Text;

namespace Registery.Controllers
{
    [Authorize]
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
        public async Task<FileResult> DownloudExcel()
        {
            var formFromDb = await _mediator.Send(new GetFormsQuery(), CancellationToken.None);
            var fileName = $"реестр {DateTime.Now}.xlsx";
            return GenerateExcel(fileName, formFromDb);
        }

        private FileResult GenerateExcel(string fileName, List<FormDto> forms)
        {
            DataTable dataTable = new DataTable("Form");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Район"),
                new DataColumn("Кадастровый номер"),
                new DataColumn("Адрес"),
                new DataColumn("Состояние в ЕГРН"),
                new DataColumn("Статус Росреестр"),
                new DataColumn("Статус ОМС"),
                new DataColumn("Дата изменения (Росреестр)"),
                new DataColumn("Автор изменения (ОМС)"),
                new DataColumn("Дата изменения (ОМС)")
            });

            foreach (var form in forms)
            {
                dataTable.Rows.Add(
                    form.DistrictNumber?.Value,
                    form.CadastralNumber,
                    form.Address,
                    form.StatusEGRN,
                    form.RosreestrStatus?.Value,
                    form.OMSStatus?.Value,
                    form.LastModifiedDateRosreestr,
                    form.LastModifiedUserOMS,
                    form.LastModifiedDateOMS
                    );
            }

            using (XLWorkbook wb = new())
            {
                wb.Worksheets.Add(dataTable);
                using(MemoryStream stream = new())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(), "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }


        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (file != null && file.Length > 0)
            {
                var uploudsFolder = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads\\";

                if (!Directory.Exists(uploudsFolder))
                {
                    Directory.CreateDirectory(uploudsFolder);
                }

                var filePath = Path.Combine(uploudsFolder, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            bool isHeaderSkipperd = false;
                            while (reader.Read())
                            {
                                if (!isHeaderSkipperd)
                                {
                                    isHeaderSkipperd = true;
                                    continue;
                                }

                                Form form = new Form();
                                form.CadastralNumber = reader.GetValue(1).ToString();
                                form.Address = reader.GetValue(2).ToString();
                                form.StatusEGRN = reader.GetValue(3).ToString();
                                form.LastModifiedDateRosreestr = Convert.ToDateTime(reader.GetValue(6));
                                form.LastModifiedDateOMS = Convert.ToDateTime(reader.GetValue(8));
                                form.LastModifiedUserOMS = reader.GetValue(7).ToString();
                                form.DistrictNumberId = _mediator.Send(new GetDistrictNumberByValueQuery(reader.GetValue(0).ToString()!), CancellationToken.None).Result?.Id;
                                form.RosreestrStatusId = _mediator.Send(new GetRosreestrStatusByValueQuery(reader.GetValue(4).ToString()!), CancellationToken.None).Result?.Id;
                                form.OMSStatusId = _mediator.Send(new GetOMSStatusByValueQuery(reader.GetValue(5).ToString()!), CancellationToken.None).Result?.Id;

                                var formFromDb = await _mediator.Send(new GetFormByCadastralNumberQuery(form.CadastralNumber!));
                                if (formFromDb == null)
                                {
                                    await _mediator.Send(_mapper.Map<AddFormCommand>(form), CancellationToken.None);
                                }
                                else
                                {
                                    form.Id = formFromDb.Id;
                                    await _mediator.Send(new DeleteFormCommand(form.Id), CancellationToken.None);
                                    await _mediator.Send(_mapper.Map<AddFormCommand>(form), CancellationToken.None);
                                }
                            }
                        } while (reader.NextResult());

                        ViewBag.Message = "success";
                    }
                }
            }
            else
                ViewBag.Message = "empty";

            return RedirectToAction(nameof(GetForms));
        }

        [HttpGet]
        public async Task<IActionResult> GetForms(int page = 1)
        {
            int pageSize = 10;
            var form = await _mediator.Send(new GetFormsWithPagination(pageSize, page), CancellationToken.None);

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
