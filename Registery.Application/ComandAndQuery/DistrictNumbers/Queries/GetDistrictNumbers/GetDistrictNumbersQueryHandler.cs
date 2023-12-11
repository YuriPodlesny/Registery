using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNambers;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.DistrictNumberDTO;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Queries.GetDistrictNumbers
{
    public class GetDistrictNambersQueryHandler : IRequestHandler<GetDistrictNumbersQuery, List<DistrictNumberDto>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public GetDistrictNambersQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DistrictNumberDto>> Handle(GetDistrictNumbersQuery request, CancellationToken cancellationToken)
        {
            var districtNumber = await _db.DistrictNumbers.ToListAsync(cancellationToken)
                ?? throw new ArgumentNullException();

            return _mapper.Map<List<DistrictNumberDto>>(districtNumber);
        }
    }
}
