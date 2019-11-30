using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlvTeam.Application.Chat.Commands.DeleteAllMessage;

namespace SlvTeam.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAllMessage()
        {
            await _mediator.Send(new DeleteAllMessageCommand());

            return RedirectToAction("Index", "Home");
        }
    }
}