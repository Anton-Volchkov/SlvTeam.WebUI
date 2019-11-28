using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SlvTeam.Application.News.Commands.AddNews
{
    public class AddNewsCommand : IRequest<bool>
    {
        public string TextNews { get; set; }
    }
}
