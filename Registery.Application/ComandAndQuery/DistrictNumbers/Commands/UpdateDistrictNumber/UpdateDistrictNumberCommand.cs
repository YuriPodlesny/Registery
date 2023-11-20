using MediatR;
using Registery.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.UpdateDistrictNumber
{
    public class UpdateDistrictNumberCommand : IRequest<APIResponse>
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
    }

}
