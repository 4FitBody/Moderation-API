namespace Moderation_API.Infrastructure.Food.Queries;

using Moderation_API.Core.Food.Models;
using MediatR;

public class GetAllQuery : IRequest<IEnumerable<Food>>
{

}