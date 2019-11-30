using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SlvTeam.Application.Chat.Commands.AddMessage
{
    public class AddMessageCommand : IRequest<bool>
    {
        public string UserID { get; set; }
        public string Text { get; set; }
    }
}
