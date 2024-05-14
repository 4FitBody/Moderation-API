namespace Moderation_API.Infrastructure.Food.Queries;

using Moderation_API.Core.Food.Models;
using MediatR;

public class GetByIdQuery : IRequest<Food>
{
    public int Id { get; set; }

    public GetByIdQuery(int Id)
    {
        this.Id = Id;
    }

    public GetByIdQuery() { }
}
