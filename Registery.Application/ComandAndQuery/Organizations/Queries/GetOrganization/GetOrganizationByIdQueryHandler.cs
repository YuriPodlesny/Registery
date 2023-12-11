using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OrganizationDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Organizations.Queries.GetOrganization
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetOrganizationByIdQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrganizationDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _db.Organizations.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(Organization));

            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
