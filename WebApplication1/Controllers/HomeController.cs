﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SlvTeam.Application.Chat.Queries.GetAllMessages;
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

        public HomeController(ILogger<HomeController> logger, UserManager<SlvTeamUser> manager, IMediator mediator,
                              SignInManager<SlvTeamUser> signInManager)
        {
            _logger = logger;
            _manager = manager;
            _mediator = mediator;
            _signInManager = signInManager;
        }

        [Authorize]
        public async Task<IActionResult> Chat()
        {
            var user = await _manager.GetUserAsync(User);
            if(!user.IsSlvTeam)
            {
                return View("Index");
            }

            var messages = await _mediator.Send(new GetAllMessagesCommand());

            var model = new ChatViewModel()
            {
                Messages = messages.OrderBy(x=>x.When).ToArray(),
                User = user
            };

            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            var userIsSlvTeam = false;
            if(_signInManager.IsSignedIn(User))
            {
                var user = await _manager.GetUserAsync(User);

                userIsSlvTeam = user.IsSlvTeam;
            }

            var news = _mediator.Send(new GetAllNewsCommand());
            return View(new HomeIndexViewModel
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