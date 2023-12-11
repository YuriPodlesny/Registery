using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Commands.UpdateOMSStatus
{
    public class UpdateOMSStatusCommandHandler : IRequestHandler<UpdateOMSStatusCommand, OMSStatusDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public UpdateOMSStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OMSStatusDto> Handle(UpdateOMSStatusCommand request, CancellationToken cancellationToken)
        {
            OMSStatus omsStatus = _mapper.Map<OMSStatus>(request);

            _db.OMSStatuses.Update(omsStatus);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OMSStatusDto>(omsStatus);
        }
    }
}
