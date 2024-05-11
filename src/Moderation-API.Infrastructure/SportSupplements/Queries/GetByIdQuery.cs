namespace Moderation_API.Infrastructure.SportSupplements.Queries;

using Moderation_API.Core.SportSupplements.Models;
using MediatR;

public class GetByIdQuery : IRequest<SportSupplement>
{
    public int? Id { get; set; }

    public GetByIdQuery(int? id)
    {
        this.Id = id;
    }

    public GetByIdQuery() { }
}