using System;
using System.Collections.Generic;
using System.Text;

namespace SlvTeam.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string TimeAnswer { get; set; }
        public string TextAnswer { get; set; }
        public string TextQuestion { get; set; }
        public string FromUserID { get; set; }

        public Question()
        {
            TimeAnswer = DateTime.UtcNow.ToString("G");
        }

        public Question(string textQuestion, string UserID) : this()
        {
            TextQuestion = textQuestion;
            FromUserID = UserID;
        }
    }
}
