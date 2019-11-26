using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Questions.Queries.GetAnsweredQuestion
{
    public class GetAnsweredQuestionCommandHandler : IRequestHandler<GetAnsweredQuestionCommand, Question[]>
    {
        private readonly ApplicationDbContext _db;

        public GetAnsweredQuestionCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<Question[]> Handle(GetAnsweredQuestionCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Questions.Where(x => x.FromUserID == request.UserID && !string.IsNullOrWhiteSpace(x.TextAnswer)).ToArray());
        }
    }
}
