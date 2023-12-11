using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OMSStatusDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.GetOMSStatus.Queries.GetQueries
{
    public class GetOMSStatusByIdQueryHandler : IRequestHandler<GetOMSStatusByIdQuery, OMSStatusDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetOMSStatusByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OMSStatusDto> Handle(GetOMSStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var omsStatus = await _db.OMSStatuses.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(OMSStatus));

            return _mapper.Map<OMSStatusDto>(omsStatus);
        }
    }
}
