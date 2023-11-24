using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumber
{
    public class GetDistrictNumberByIdQueryHandler : IRequestHandler<GetDistrictNumberByIdQuery, DistrictNumberDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetDistrictNumberByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DistrictNumberDto> Handle(GetDistrictNumberByIdQuery request, CancellationToken cancellationToken)
        {
            var districtNamber = await _db.DistrictNumbers.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(DistrictNumber));

            return _mapper.Map<DistrictNumberDto>(districtNamber); ;
        }
    }
}
