using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Questions.Queries.GetUnansweredQuestion
{
    public class GetUnansweredQuestionCommandHandler : IRequestHandler<GetUnansweredQuestionCommand, Question[]>
    {
        private readonly ApplicationDbContext _db;

        public GetUnansweredQuestionCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Question[]> Handle(GetUnansweredQuestionCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Questions.Where(x => string.IsNullOrWhiteSpace(x.TextAnswer) &&
                                                            x.FromUserID == request.UserID).ToArray());
        }
    }
}