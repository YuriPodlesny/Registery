using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.AddRosreestrStatus
{
    public class AddRosreestrStatusCommandHandler : IRequestHandler<AddRosreestrStatusCommand, APIResponse>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public AddRosreestrStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        public async Task<APIResponse> Handle(AddRosreestrStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var rosreestrStatus = new RosreestrStatus
                {
                    Value = request.Value
                };

                await _db.RosreestrStatuses.AddAsync(rosreestrStatus, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                _response.Result = _mapper.Map<RosreestrStatusDto>(rosreestrStatus);
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
