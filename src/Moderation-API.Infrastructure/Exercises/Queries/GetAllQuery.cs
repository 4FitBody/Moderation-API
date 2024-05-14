namespace Moderation_API.Infrastructure.Exercises.Queries;

using Moderation_API.Core.Exercises.Models;
using MediatR;

public class GetAllQuery : IRequest<IEnumerable<Exercise>>
{

}