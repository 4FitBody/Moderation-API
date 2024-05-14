namespace Moderation_API.Infrastructure.Food.Handlers;

using Moderation_API.Core.Food.Repositories;
using Moderation_API.Infrastructure.Food.Commands;
using MediatR;

public class ApproveHandler : IRequestHandler<ApproveCommand>
{
    private readonly IFoodRepository foodRepository;

    public ApproveHandler(IFoodRepository foodRepository) => this.foodRepository = foodRepository;

    public async Task Handle(ApproveCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Id);

        await this.foodRepository.ApproveAsync((int)request.Id);
    }
}