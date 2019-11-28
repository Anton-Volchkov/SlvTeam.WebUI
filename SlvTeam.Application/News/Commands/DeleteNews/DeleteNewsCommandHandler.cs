using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace SlvTeam.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        public DeleteNewsCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _db.News.FirstOrDefaultAsync(x => x.Id == request.NewsID);

            if(news is null)
            {
                return false;
            }

            _db.News.Remove(news);

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
