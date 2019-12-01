using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Chat.Commands.AddMessage
{
    public class AddMessageCommandHandler:IRequestHandler<AddMessageCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<SlvTeamUser> _manager;
        public AddMessageCommandHandler(ApplicationDbContext db, UserManager<SlvTeamUser> manager)
        {
            _db = db;
            _manager = manager;
        }
        public async Task<bool> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var user = await _manager.FindByIdAsync(request.UserID);

            var msg = new Message()
            {
                UserName = $"{user.FirstName} {user.LastName}",
                SlvTeamUserID = request.UserID,
                Text = request.Text
            };

             await _db.Messages.AddAsync(msg);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
