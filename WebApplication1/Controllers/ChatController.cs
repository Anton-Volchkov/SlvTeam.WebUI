using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SlvTeam.Application.Chat.Commands.AddMessage;
using WebApplication1.Data;

namespace SlvTeam.WebUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly IMediator _mediator;
        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddMessage(string text, string userId)
        {
            await _mediator.Send(new AddMessageCommand() { Text = text, UserID = userId });
        }
    }
}