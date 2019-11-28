using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Profiles.Queries.GetProfileById
{
    public class GetProfileByIdCommand : IRequest<SlvTeamUser>
    {
        public string UserID { get; set; }
    }
}