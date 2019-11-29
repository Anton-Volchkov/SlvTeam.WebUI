using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlvTeam.Application.News.Commands.AddNews;
using SlvTeam.Application.News.Commands.DeleteNews;

namespace SlvTeam.WebUI.Controllers
{
    [Authorize]
    public class SlvTeamNewsController : Controller
    {
        private readonly IMediator _mediator;

        public SlvTeamNewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(string textNews)
        {
            await _mediator.Send(new AddNewsCommand
            {
                TextNews = textNews
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNews(int newsID)
        {
            await _mediator.Send(new DeleteNewsCommand
            {
                NewsID = newsID
            });

            return RedirectToAction("Index", "Home");
        }
    }
}