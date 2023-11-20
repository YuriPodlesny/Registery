using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus
{
    public class UpdateOMSStatusCommandHandler : IRequestHandler<UpdateOMSStatusCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public UpdateOMSStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(UpdateOMSStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var omsStatus = _mapper.Map<OMSStatus>(request);
                _db.OMSStatuses.Update(omsStatus);
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
