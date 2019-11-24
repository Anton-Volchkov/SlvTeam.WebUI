using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SlvTeam.Application.Users.Commands.AddLocation;
using SlvTeam.Domain.Entities;

namespace WebApplication1.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<SlvTeamUser> _manager;
        private readonly IMediator _mediator;

        public LocationController(ILogger<HomeController> logger, UserManager<SlvTeamUser> manager, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _manager = manager;
        }


        [Authorize]
        [HttpPost]
        public async Task SetLocation(string lat, string lon)
        {
            var user = await _manager.GetUserAsync(User);
            var text = await _mediator.Send(new AddLocationCommand
            {
                User = user,
                Lat = lat,
                Lon = lon
            });
        }
    }
}