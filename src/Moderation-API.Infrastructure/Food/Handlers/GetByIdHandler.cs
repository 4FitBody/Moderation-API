namespace Moderation_API.Infrastructure.Food.Handlers;

using System;
using System.Linq;
using System.Threading.Tasks;
using Moderation_API.Core.Food.Repositories;
using Moderation_API.Core.Food.Models;
using Moderation_API.Infrastructure.Food.Queries;
using MediatR;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, Food>
{
    private readonly IFoodRepository repository;

    public GetByIdHandler(IFoodRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Food> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await repository.GetByIdAsync(request.Id);

        if (food is null)
        {
            throw new ArgumentNullException("No food by this Id");
        }

        return food;
    }
}