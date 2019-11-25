using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlvTeam.Application.Profiles.Queries.GetAllProfiles;
using SlvTeam.Domain.Entities;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfilesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<SlvTeamUser> _manager;
        public ProfilesController(IMediator mediator, UserManager<SlvTeamUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users =_mediator.Send(new GetAllProfilesCommnad()).Result;
            return View(users);
        }

    
        public async Task<IActionResult> SetSlvTeamStatus(string userID)
        {
            var user = await _manager.FindByIdAsync(userID);

            user.IsSlvTeam = !user.IsSlvTeam;
            await _manager.UpdateAsync(user);

            return RedirectToAction("AllUsers", "Profiles");
        }

    }
}