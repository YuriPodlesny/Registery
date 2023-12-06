using MediatR;
using Registery.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.DeleteOrganization
{
    public record DeleteOrganizationCommand(Guid Id) : IRequest<Unit>;

}
