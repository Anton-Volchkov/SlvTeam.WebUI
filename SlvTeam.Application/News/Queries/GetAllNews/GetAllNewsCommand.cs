using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SlvTeam.Application.News.Queries.GetAllNews
{
    public class GetAllNewsCommand : IRequest<Domain.Entities.News[]>
    {
    }
}
