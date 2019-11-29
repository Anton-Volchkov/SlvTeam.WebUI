using MediatR;

namespace SlvTeam.Application.News.Queries.GetAllNews
{
    public class GetAllNewsCommand : IRequest<Domain.Entities.News[]> { }
}