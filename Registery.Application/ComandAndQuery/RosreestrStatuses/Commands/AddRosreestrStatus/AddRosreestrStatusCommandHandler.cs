using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.AddRosreestrStatus
{
    public class AddRosreestrStatusCommandHandler : IRequestHandler<AddRosreestrStatusCommand, RosreestrStatusDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public AddRosreestrStatusCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RosreestrStatusDto> Handle(AddRosreestrStatusCommand request, CancellationToken cancellationToken)
        {
            var rosreestrStatus = _mapper.Map<RosreestrStatus>(request);

            await _db.RosreestrStatuses.AddAsync(rosreestrStatus, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RosreestrStatusDto>(rosreestrStatus);
        }
    }
}
