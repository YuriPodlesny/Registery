using MediatR;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommand : IRequest<OrganizationDto>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string INN { get; set; }
        public Guid DistrictNumberId { get; set; }
    }
}
