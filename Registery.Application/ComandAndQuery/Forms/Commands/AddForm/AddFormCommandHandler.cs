﻿using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Forms.Commands.AddForm
{
    public class AddFormCommandHandler : IRequestHandler<AddFormCommand, FormDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public AddFormCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FormDto> Handle(AddFormCommand request, CancellationToken cancellationToken)
        {
            var form = _mapper.Map<Form>(request);

            await _db.Forms.AddAsync(form, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<FormDto>(form);
        }
    }

}
