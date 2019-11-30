using System;
using System.Collections.Generic;
using System.Text;

namespace SlvTeam.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Text { get; set; }
        public string When { get; set; }

        public string SlvTeamUserID { get; set; }
        public virtual SlvTeamUser SlvTeamUser { get; set; }
        public Message()
        {
            When = DateTime.Now.ToString("G");

        }
    }
}
