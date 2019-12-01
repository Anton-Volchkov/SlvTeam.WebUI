using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace SlvTeam.Application.Chat.Commands.DeleteAllMessage
{
    public class DeleteAllMessageCommandHandler : IRequestHandler<DeleteAllMessageCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        public DeleteAllMessageCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteAllMessageCommand request, CancellationToken cancellationToken)
        {
      
           _db.Messages.RemoveRange(_db.Messages);

           await _db.SaveChangesAsync();

           return true;
        }
    }
}
