using MediatR;

namespace SlvTeam.Application.Questions.Commands.AddAnswerOnQuestion
{
    public class AddAnswerOnQuestionCommand : IRequest<bool>
    {
        public string Answer { get; set; }
        public int IdQuestion { get; set; }
        public string UserID { get; set; }
    }
}