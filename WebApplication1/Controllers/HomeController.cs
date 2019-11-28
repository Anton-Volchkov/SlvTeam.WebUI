using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SlvTeam.Application.News.Queries.GetAllNews;
using SlvTeam.Domain.Entities;
using SlvTeam.Domain.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<SlvTeamUser> _manager;
        private readonly IMediator _mediator;
        private readonly SignInManager<SlvTeamUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<SlvTeamUser> manager, IMediator mediator, SignInManager<SlvTeamUser> signInManager)
        {
            _logger = logger;
            _manager = manager;
            _mediator = mediator;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            bool userIsSlvTeam = false;
            if(_signInManager.IsSignedIn(User))
            {
                var user = await _manager.GetUserAsync(User);

                userIsSlvTeam = user.IsSlvTeam;
            }
            
            var news = _mediator.Send(new GetAllNewsCommand());
            return View(new HomeIndexViewModel()
            {
                News = news.Result.Reverse().ToArray(),
                IsSlvTeam = userIsSlvTeam

            });
        }

        public IActionResult Success()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}