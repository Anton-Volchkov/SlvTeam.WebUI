using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlvTeam.Application.News.Commands.AddNews;
using SlvTeam.Application.News.Commands.DeleteNews;
using SlvTeam.Domain.Entities;

namespace SlvTeam.WebUI.Controllers
{
    [Authorize]
    public class SlvTeamNewsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<SlvTeamUser> _manager;

        public SlvTeamNewsController(IMediator mediator,UserManager<SlvTeamUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(string textNews)
        {
            var user = await _manager.GetUserAsync(User);

            if(!user.IsSlvTeam)
            {
                RedirectToAction("Index", "Home");
            }

            await _mediator.Send(new AddNewsCommand
            {
                TextNews = textNews
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNews(int newsID)
        {
            var user = await _manager.GetUserAsync(User);

            if (!user.IsSlvTeam)
            {
                RedirectToAction("Index", "Home");
            }

            await _mediator.Send(new DeleteNewsCommand
            {
                NewsID = newsID
            });

            return RedirectToAction("Index", "Home");
        }
    }
}