using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SlvTeam.Application.Questions.Commands.DeleteQuestionById
{
    public class DeleteQuestionByIdCommand : IRequest<bool>
    {
        public int QuestionID { get; set; }
    }
}
