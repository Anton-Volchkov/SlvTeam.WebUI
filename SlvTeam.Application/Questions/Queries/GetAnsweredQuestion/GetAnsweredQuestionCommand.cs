using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Questions.Queries.GetAnsweredQuestion
{
    public class GetAnsweredQuestionCommand : IRequest<Question[]>
    {
        public string UserID { get; set; }
    }
}