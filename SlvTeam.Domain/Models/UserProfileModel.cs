using SlvTeam.Domain.Entities;

namespace SlvTeam.Domain.Models
{
    public class UserProfileModel
    {
        public SlvTeamUser User { get; set; }

        public Question[] Questions { get; set; }
    }
}