using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatus
{
    public class GetRosreestrStatusByIdQueryHandler : IRequestHandler<GetRosreestrStatusByIdQuery, RosreestrStatusDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetRosreestrStatusByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RosreestrStatusDto> Handle(GetRosreestrStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var rosreestrStatus = await _db.RosreestrStatuses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                 ?? throw new ArgumentNullException(nameof(RosreestrStatus));

            return _mapper.Map<RosreestrStatusDto>(rosreestrStatus);
        }
    }
}
