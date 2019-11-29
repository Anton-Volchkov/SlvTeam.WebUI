using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlvTeam.Application.Questions.Commands.AddAnswerOnQuestion;
using SlvTeam.Application.Questions.Commands.AddQuestion;
using SlvTeam.Application.Questions.Commands.DeleteQuestionById;
using SlvTeam.Application.Questions.Queries.GetUnansweredQuestion;
using SlvTeam.Domain.Entities;

namespace WebApplication1.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<SlvTeamUser> _manager;

        public QuestionsController(IMediator mediator, UserManager<SlvTeamUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(string textQuestion, string userID)
        {
            var result = await _mediator.Send(new AddQuestionCommand
            {
                Question = textQuestion,
                UserID = userID
            });

            return RedirectToAction("Success", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int questionID, string returnUrl = "")
        {
            await _mediator.Send(new DeleteQuestionByIdCommand { QuestionID = questionID });

            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> SetAnswerOnQuestion(string textAnswer, int questionID)
        {
            await _mediator.Send(new AddAnswerOnQuestionCommand
            {
                Answer = textAnswer,
                IdQuestion = questionID
            });

            return RedirectToAction("UnansweredQuestion", "Questions");
        }

        [HttpGet]
        public async Task<IActionResult> UnansweredQuestion()
        {
            var user = await _manager.GetUserAsync(User);
            var model = await _mediator.Send(new GetUnansweredQuestionCommand { UserID = user.Id });

            return View(model);
        }
    }
}