﻿using MediatR;
using Registery.Application.Models;
using Registry.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registery.Application.ComandAndQuery.Forms.Commands.AddForm
{
    public class AddFormCommand : IRequest<APIResponse>
    {
        public string? CadastralNumber { get; set; }
        public string Address { get; set; }
        public string? StatusEGRN { get; set; }
        public DateTime LastModifiedDateRosreestr { get; set; }
        public DateTime LastModifiedDateOMS { get; set; }
        public string? LastModifiedUserOMS { get; set; }


        public Guid? DistrictNumberId { get; set; }
        public Guid? RosreestrStatusId { get; set; }
        public Guid? OMSStatusId { get; set; }
    }
}
