using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public UpdateFormCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var form = _mapper.Map<Form>(request);
                _db.Forms.Update(form);
                await _db.SaveChangesAsync(cancellationToken);
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
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
