using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace SlvTeam.Application.Profiles.Queries.GetSlvTeamProfiles
{
    public class GetSlvTeamProfilesCommandHandler:IRequestHandler<GetSlvTeamProfilesCommand, SlvTeamUser[]>
    {
        private readonly ApplicationDbContext _db;
        public GetSlvTeamProfilesCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<SlvTeamUser[]> Handle(GetSlvTeamProfilesCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Users.Where(x => x.IsSlvTeam).ToArray());
        }
    }
}
