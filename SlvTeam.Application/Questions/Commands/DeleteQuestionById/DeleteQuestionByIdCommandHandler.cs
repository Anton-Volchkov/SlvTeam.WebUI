using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace SlvTeam.Application.Questions.Commands.DeleteQuestionById
{
    public class DeleteQuestionByIdCommandHandler : IRequestHandler<DeleteQuestionByIdCommand,bool>
    {
        private readonly ApplicationDbContext _db;
        public DeleteQuestionByIdCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteQuestionByIdCommand request, CancellationToken cancellationToken)
        {
            var question = await _db.Questions.FirstOrDefaultAsync(x => x.Id == request.QuestionID);

            if(question is null)
            {
                return false;
            }

            _db.Questions.Remove(question);

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
