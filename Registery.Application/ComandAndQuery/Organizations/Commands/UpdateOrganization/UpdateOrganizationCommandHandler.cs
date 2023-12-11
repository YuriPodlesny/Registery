using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.OrganizationDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, OrganizationDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public UpdateOrganizationCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrganizationDto> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = _mapper.Map<Organization>(request);

            _db.Organizations.Update(organization);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
