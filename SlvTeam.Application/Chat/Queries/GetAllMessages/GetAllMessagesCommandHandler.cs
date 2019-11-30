using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Chat.Queries.GetAllMessages
{
    public class GetAllMessagesCommandHandler : IRequestHandler<GetAllMessagesCommand, Message[]>
    {
        private readonly ApplicationDbContext _db;
        public GetAllMessagesCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Message[]> Handle(GetAllMessagesCommand request, CancellationToken cancellationToken)
        {
            return await _db.Messages.ToArrayAsync();
        }
    }
}
