namespace Moderation_API.Infrastructure.SportSupplements.Handlers;

using Moderation_API.Infrastructure.SportSupplements.Queries;
using Moderation_API.Core.SportSupplements.Models;
using MediatR;
using Moderation_API.Core.SportSupplements.Repositories;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, SportSupplement>
{
    private readonly ISportSupplementRepository supplementRepository;

    public GetByIdHandler(ISportSupplementRepository supplementRepository) => this.supplementRepository = supplementRepository;

    public async Task<SportSupplement> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Id);

        var sportSupplement = await this.supplementRepository.GetByIdAsync((int)request.Id);

        if (sportSupplement is null)
        {
            return new SportSupplement();
        }

        return sportSupplement!;
    }
}