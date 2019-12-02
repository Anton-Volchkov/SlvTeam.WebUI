using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int questionID, string returnUrl = "")
        {
            var user = await _manager.GetUserAsync(User);

            await _mediator.Send(new DeleteQuestionByIdCommand
            {
                QuestionID = questionID,
                UserID = user.Id
            });

            return LocalRedirect(returnUrl);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SetAnswerOnQuestion(string textAnswer, int questionID)
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new AddAnswerOnQuestionCommand
            {
                Answer = textAnswer,
                IdQuestion = questionID,
                UserID = user.Id
            });

            return RedirectToAction("UnansweredQuestion", "Questions");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UnansweredQuestion()
        {
            var user = await _manager.GetUserAsync(User);
            var model = await _mediator.Send(new GetUnansweredQuestionCommand { UserID = user.Id });

            return View(model);
        }
    }
}