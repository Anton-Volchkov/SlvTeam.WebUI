using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Chat.Queries.GetAllMessages
{
    public class GetAllMessagesCommand : IRequest<Message[]>
    {
    }
}
