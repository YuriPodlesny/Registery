using MediatR;
using Registery.Application.Mapping.DistrictNumberDTO;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.AddDistrictNumber
{
    public class AddDistrictNumberCommand : IRequest<DistrictNumberDto>
    {
        public string? Value { get; set; }
    }
}
