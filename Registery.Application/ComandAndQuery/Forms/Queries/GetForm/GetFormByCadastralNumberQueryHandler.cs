using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;
using Registery.Application.Mapping.FormDTO;
using Registry.Domain.Entities;

namespace Registery.Application.ComandAndQuery.Forms.Queries.GetForm
{
    public class GetFormByCadastralNumberQueryHandler : IRequestHandler<GetFormByCadastralNumberQuery, FormDto?>
    {
        private readonly IBaseDbContext _db;
        private readonly IMapper _mapper;

        public GetFormByCadastralNumberQueryHandler(IBaseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<FormDto?> Handle(GetFormByCadastralNumberQuery request, CancellationToken cancellationToken)
        {
            var formFromDb = await _db.Forms.AsNoTracking().FirstOrDefaultAsync(e => e.CadastralNumber == request.CadastralNumber, cancellationToken);
            
            if (formFromDb == null)
            {
                return null;
            }

            return _mapper.Map<FormDto>(formFromDb);
        }
    }
}
