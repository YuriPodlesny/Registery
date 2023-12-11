using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OrganizationDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization
{
    public class AddOrganizationCommandHandler : IRequestHandler<AddOrganizationCommand, OrganizationDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public AddOrganizationCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrganizationDto> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = _mapper.Map<Organization>(request);

            await _db.Organizations.AddAsync(organization, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
