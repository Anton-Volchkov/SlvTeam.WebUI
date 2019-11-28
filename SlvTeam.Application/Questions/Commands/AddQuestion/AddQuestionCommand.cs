using MediatR;

namespace SlvTeam.Application.Questions.Commands.AddQuestion
{
    public class AddQuestionCommand : IRequest<bool>
    {
        public string UserID { get; set; }
        public string Question { get; set; }
    }
}