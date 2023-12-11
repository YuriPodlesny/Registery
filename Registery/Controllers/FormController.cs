using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registery.Application.ComandAndQuery.Forms.Queries.GetForms;

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

        

    }
}
