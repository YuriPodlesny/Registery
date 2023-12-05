using MediatR;
using Registery.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber
{
    public record DeleteDistrictNumberCommand(Guid Id) : IRequest<Unit>;

}
