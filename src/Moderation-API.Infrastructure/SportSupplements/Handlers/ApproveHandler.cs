namespace Moderation_API.Infrastructure.SportSupplements.Handlers;

using Moderation_API.Core.SportSupplements.Repositories;
using Moderation_API.Infrastructure.SportSupplements.Commands;
using MediatR;

public class ApproveHandler : IRequestHandler<ApproveCommand>
{
    private readonly ISportSupplementRepository sportSupplementRepository;

    public ApproveHandler(ISportSupplementRepository sportSupplementRepository) => this.sportSupplementRepository = sportSupplementRepository;

    public async Task Handle(ApproveCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Id);

        await this.sportSupplementRepository.ApproveAsync((int)request.Id);
    }
}