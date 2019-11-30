using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SlvTeam.Application.Chat.Commands.DeleteAllMessage
{
    public class DeleteAllMessageCommand : IRequest<bool>
    {
    }
}
