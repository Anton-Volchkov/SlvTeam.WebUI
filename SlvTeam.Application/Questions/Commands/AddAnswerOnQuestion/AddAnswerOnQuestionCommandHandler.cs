﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SlvTeam.Domain.Entities;
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

            if(question is null || question.FromUserID != request.UserID)
            {
                return false;
            }

            question.TextAnswer = request.Answer;
            question.TimeAnswer = DateTime.Now.ToString("G");

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}