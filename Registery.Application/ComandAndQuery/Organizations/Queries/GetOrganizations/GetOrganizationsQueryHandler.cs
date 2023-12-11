using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OrganizationDTO;

namespace Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganizations
{
    public class GetOrganizationsQueryHandler : IRequestHandler<GetOrganizationsQuery, List<OrganizationDto>>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public GetOrganizationsQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<OrganizationDto>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizationFromDb = await _db.Organizations.Include(e => e.DistrictNumber).ToListAsync(cancellationToken);

            return _mapper.Map<List<OrganizationDto>>(organizationFromDb);
        }
    }
}
