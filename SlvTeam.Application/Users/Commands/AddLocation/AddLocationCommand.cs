using MediatR;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Users.Commands.AddLocation
{
    public class AddLocationCommand : IRequest<bool>
    {
        public SlvTeamUser User { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}