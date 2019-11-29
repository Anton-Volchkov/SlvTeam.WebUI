using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApplication1.Data;

namespace SlvTeam.Application.News.Queries.GetAllNews
{
    public class GetAllNewsCommandHandler : IRequestHandler<GetAllNewsCommand, Domain.Entities.News[]>
    {
        private readonly ApplicationDbContext _db;

        public GetAllNewsCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Domain.Entities.News[]> Handle(GetAllNewsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.News.ToArray());
        }
    }
}