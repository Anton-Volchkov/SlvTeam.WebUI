using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Profiles.Queries.GetAllProfiles
{
    public class GetAllProfilesCommnad:IRequest<SlvTeamUser[]>
    {
    }
}
