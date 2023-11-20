using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus
{
    public class AddOMSStatusCommandHandler : IRequestHandler<AddOMSStatusCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AddOMSStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(AddOMSStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var omsStatus = new OMSStatus
                {
                    Value = request.Value
                };

                await _db.OMSStatuses.AddAsync(omsStatus, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                _response.Result = _mapper.Map<OMSStatusDto>(omsStatus);
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
