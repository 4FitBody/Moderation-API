namespace Moderation_API.Infrastructure.SportSupplements.Queries;

using Moderation_API.Core.SportSupplements.Models;
using MediatR;


public class GetAllQuery : IRequest<IEnumerable<SportSupplement>>
{

}
