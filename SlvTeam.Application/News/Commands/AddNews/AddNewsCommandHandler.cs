using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApplication1.Data;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.News.Commands.AddNews
{
    public class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, bool>
    {
        private readonly ApplicationDbContext _db;

        public AddNewsCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
           Domain.Entities.News news = new Domain.Entities.News(request.TextNews);

           await _db.News.AddAsync(news);
           await _db.SaveChangesAsync();

           return true;
        }
    }
}
