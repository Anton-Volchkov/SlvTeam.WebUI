using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Profiles.Queries.GetAllProfiles
{
    public class GetAllProfilesCommandHandler : IRequestHandler<GetAllProfilesCommnad, SlvTeamUser[]>
    {
        private readonly ApplicationDbContext _db;
        public GetAllProfilesCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<SlvTeamUser[]> Handle(GetAllProfilesCommnad request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Users.ToArray());
        }
    }
}
