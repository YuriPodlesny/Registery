using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatus
{
    public record GetRosreestrStatusByIdQuery(Guid Id) : IRequest<RosreestrStatusDto>;

}
