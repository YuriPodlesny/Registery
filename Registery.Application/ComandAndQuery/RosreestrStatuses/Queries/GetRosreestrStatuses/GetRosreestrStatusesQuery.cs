﻿using MediatR;
using Registery.Application.Mapping.RosreestrStatusDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.RosreestrStatuses.Queries.GetRosreestrStatuses
{
    public record GetRosreestrStatusesQuery : IRequest<List<RosreestrStatusDto>>;

}
