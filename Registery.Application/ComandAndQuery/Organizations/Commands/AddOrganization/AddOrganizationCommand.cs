using MediatR;
using Registery.Application.Mapping.OrganizationDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.AddOrganization
{
    public class AddOrganizationCommand : IRequest<OrganizationDto>
    {
        public required string Name { get; set; }
        public required string INN { get; set; }
        public Guid DistrictNumberId { get; set; }
    }
}
