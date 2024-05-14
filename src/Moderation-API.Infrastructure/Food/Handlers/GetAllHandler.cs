namespace Moderation_API.Infrastructure.Food.Handlers;

using Moderation_API.Infrastructure.Food.Queries;
using Moderation_API.Core.Food.Models;
using MediatR;
using Moderation_API.Core.Food.Repositories;

public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<Food>>
{
    private readonly IFoodRepository foodRepository;

    public GetAllHandler(IFoodRepository foodRepository) => this.foodRepository = foodRepository;

    public async Task<IEnumerable<Food>?> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var food = await this.foodRepository.GetAllAsync();

        if (food is null)
        {
            return Enumerable.Empty<Food>();
        }

        return food;
    }
}