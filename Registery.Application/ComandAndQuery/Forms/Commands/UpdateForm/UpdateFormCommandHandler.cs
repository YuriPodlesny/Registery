using AutoMapper;
using MediatR;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Forms.Commands.UpdateForm
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, FormDto>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;
        public UpdateFormCommandHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FormDto> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            var form = _mapper.Map<Form>(request);

            _db.Forms.Update(form);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<FormDto>(form);
        }
    }
}
