using MediatR;
using SlvTeam.Domain.Entities;
using SlvTeam.Domain.Models;

namespace SlvTeam.Application.Profiles.Commands.EditProfile
{
    public class EditProfileCommand : IRequest<SlvTeamUser>
    {
        public EditProfileViewModel Model { get; set; }
    }
}