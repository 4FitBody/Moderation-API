namespace Moderation_API.Infrastructure.Exercises.Queries;

using Moderation_API.Core.Exercises.Models;
using MediatR;

public class GetByIdQuery : IRequest<Exercise>
{
    public int? Id { get; set; }

    public GetByIdQuery(int? id)
    {
        this.Id = id;
    }

    public GetByIdQuery() { }
}