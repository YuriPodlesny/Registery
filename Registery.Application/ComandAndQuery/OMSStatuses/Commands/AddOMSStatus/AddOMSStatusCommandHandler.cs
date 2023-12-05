using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System.Net;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.AddOMSStatus
{
    public class AddOMSStatusCommandHandler : IRequestHandler<AddOMSStatusCommand, OMSStatusDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public AddOMSStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OMSStatusDto> Handle(AddOMSStatusCommand request, CancellationToken cancellationToken)
        {
            var omsStatus = _mapper.Map<OMSStatus>(request);

            await _db.OMSStatuses.AddAsync(omsStatus, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OMSStatusDto>(omsStatus);
        }
    }
}
