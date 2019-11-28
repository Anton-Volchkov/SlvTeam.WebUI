using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Profiles.Queries.GetProfileById
{
    public class GetProfileByIdCommandHandler : IRequestHandler<GetProfileByIdCommand, SlvTeamUser>
    {
        private readonly ApplicationDbContext _db;

        public GetProfileByIdCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SlvTeamUser> Handle(GetProfileByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == request.UserID);

            if(user is null)
            {
                throw new NullReferenceException("Пользователь с таким ID не найден.");
            }

            return user;
        }
    }
}