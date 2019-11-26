using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace SlvTeam.Application.Questions.Commands.AddAnswerOnQuestion
{
    public class AddAnswerOnQuestionCommandHandler : IRequestHandler<AddAnswerOnQuestionCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        public AddAnswerOnQuestionCommandHandler(ApplicationDbContext db)
        {
            _db = db;   
        }
        public async Task<bool> Handle(AddAnswerOnQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _db.Questions.FirstOrDefaultAsync(x => x.Id == request.IdQuestion);
           
            if(question is null)
            {
                return false;
            }

            question.TextAnswer = request.Answer;

            await _db.SaveChangesAsync(cancellationToken);

            return true;

        }
    }
}
