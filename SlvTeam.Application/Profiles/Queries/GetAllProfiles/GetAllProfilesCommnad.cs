using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Profiles.Queries.GetAllProfiles
{
    public class GetAllProfilesCommnad : IRequest<SlvTeamUser[]> { }
}