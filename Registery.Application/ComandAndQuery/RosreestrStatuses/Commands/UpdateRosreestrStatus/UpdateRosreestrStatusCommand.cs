using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Commands.UpdateRosreestrStatus
{
    public class UpdateRosreestrStatusCommand : IRequest<RosreestrStatusDto>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }
}
