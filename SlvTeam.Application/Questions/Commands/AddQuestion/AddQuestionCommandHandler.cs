using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Questions.Commands.AddQuestion
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, bool>
    {
        private readonly ApplicationDbContext _db;

        public AddQuestionCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question(request.Question, request.UserID);

            _db.Questions.Add(question);

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}