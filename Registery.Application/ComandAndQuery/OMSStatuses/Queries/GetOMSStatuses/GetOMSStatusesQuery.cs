using MediatR;
using Registery.Application.Mapping.OMSStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.OMSStatuses.Queries.GetOMSStatuses
{
    public record GetOMSStatusesQuery : IRequest<List<OMSStatusDto>>;
}
