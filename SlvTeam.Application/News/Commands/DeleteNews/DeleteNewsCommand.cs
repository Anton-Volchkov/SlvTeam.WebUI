using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SlvTeam.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest<bool>
    {
        public int NewsID { get; set; }
    }
}
