using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.Forms.Commands.AddForm
{
    public class AddFormCommandHandler : IRequestHandler<AddFormCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AddFormCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(AddFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var form = _mapper.Map<Form>(request);
                
                await _db.Forms.AddAsync(form, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                _response.Result = _mapper.Map<FormCreateDto>(form);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }

}
