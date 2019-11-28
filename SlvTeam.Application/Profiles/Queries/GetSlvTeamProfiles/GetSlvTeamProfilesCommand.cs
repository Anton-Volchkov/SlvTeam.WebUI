using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Profiles.Queries.GetSlvTeamProfiles
{
    public class GetSlvTeamProfilesCommand : IRequest<SlvTeamUser[]> { }
}