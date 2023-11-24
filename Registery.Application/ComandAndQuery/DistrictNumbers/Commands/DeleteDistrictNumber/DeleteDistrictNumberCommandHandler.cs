using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;

namespace Registery.Application.ComandAndQuery.DistrictNumbers.Commands.DeleteDistrictNumber
{
    public class DeleteDistrictNumberCommandHandler : IRequestHandler<DeleteDistrictNumberCommand, Unit>
    {
        private readonly IBaseDbContext _db;
        public DeleteDistrictNumberCommandHandler(IBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteDistrictNumberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var districtNamberFronDb = await _db.DistrictNumbers.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (districtNamberFronDb is null)
                {
                    throw new ArgumentNullException(nameof(districtNamberFronDb));
                }
                districtNamberFronDb.Delete = true;
                _db.DistrictNumbers.UpdateRange(districtNamberFronDb);
                await _db.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                new List<string> { ex.Message };
            }

            return Unit.Value;
        }
    }
}

