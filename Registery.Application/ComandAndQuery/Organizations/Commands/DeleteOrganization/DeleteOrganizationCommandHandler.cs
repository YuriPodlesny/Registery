using MediatR;
using Microsoft.EntityFrameworkCore;
using Registery.Application.Interfaces;

namespace Registery.Application.ComandAndQuery.Organizations.Commands.DeleteOrganization
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, Unit>
    {
        private readonly IBaseDbContext _db;

        public DeleteOrganizationCommandHandler(IBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var organizationFronDb = await _db.Organizations.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

                if (organizationFronDb is null)
                {
                    throw new ArgumentNullException(nameof(organizationFronDb));
                }
                organizationFronDb.Delete = true;
                _db.Organizations.UpdateRange(organizationFronDb);
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
