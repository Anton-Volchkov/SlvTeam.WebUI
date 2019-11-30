using System;
using System.Collections.Generic;
using System.Text;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Domain.Models
{
    public class ChatViewModel
    {
        public Message[] Messages { get; set; }

        public SlvTeamUser User { get; set; }
    }
}
