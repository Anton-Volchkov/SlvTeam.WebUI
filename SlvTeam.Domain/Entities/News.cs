using System;
using System.Collections.Generic;
using System.Text;

namespace SlvTeam.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string TextNews { get; set; }

        public string TimeNews { get; set; }
        public News()
        {
            TimeNews = DateTime.Now.ToString("G");
        }

        public News(string textNews) : this()
        {
            TextNews = textNews;
        }
    }
}
