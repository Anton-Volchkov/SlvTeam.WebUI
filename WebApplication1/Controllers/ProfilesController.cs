using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SlvTeam.Application.Profiles.Commands.EditProfile;
using SlvTeam.Domain.Entities;
using SlvTeam.Domain.Models;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<SlvTeamUser> _manager;
        private readonly ApplicationDbContext _db;
        private readonly IMediator _mediator;
        public ProfilesController(ILogger<HomeController> logger, UserManager<SlvTeamUser> manager, ApplicationDbContext db, IMediator mediator)
        {
            _logger = logger;
            _manager = manager;
            _db = db;
            _mediator = mediator;
        }

        
        public async Task<IActionResult> GetEditProfilePage()
        {
            var user = await _manager.GetUserAsync(User);
            var model = new EditProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Address,
                AboutAs = user.AboutAs,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Id = user.Id,
                ImagePath = default
            };

            return View("EditProfile", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile([FromForm] EditProfileViewModel newUser)
        {
            var user = await _manager.GetUserAsync(User);

            await _mediator.Send(new EditProfileCommand
            {
               Model = newUser
            });

            return RedirectToAction("Profile", "Profile");
        }


        public async Task<IActionResult> Profile()
        {
            var user = await _manager.GetUserAsync(User);
            return View(user);
        }

    }
}