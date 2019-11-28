using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SlvTeam.Application.Profiles.Commands.EditProfile;
using SlvTeam.Application.Profiles.Queries.GetProfileById;
using SlvTeam.Application.Profiles.Queries.GetSlvTeamProfiles;
using SlvTeam.Application.Questions.Queries.GetAnsweredQuestion;
using SlvTeam.Domain.Entities;
using SlvTeam.Domain.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<SlvTeamUser> _manager;
        private readonly ApplicationDbContext _db;
        private readonly IMediator _mediator;
        private readonly SignInManager<SlvTeamUser> _signInManager;

        public ProfilesController(ILogger<HomeController> logger, UserManager<SlvTeamUser> manager,
                                  ApplicationDbContext db, IMediator mediator, SignInManager<SlvTeamUser> signInManager)
        {
            _logger = logger;
            _manager = manager;
            _db = db;
            _mediator = mediator;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult SlvTeam()
        {
            var slvTeamUsers = _mediator.Send(new GetSlvTeamProfilesCommand()).Result;
            return View("SlvTeamProfiles", slvTeamUsers);
        }

        [Authorize]
        public async Task<IActionResult> EditProfilePage()
        {
            var user = await _manager.GetUserAsync(User);
            var model = new EditProfileViewModel
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

        [HttpGet]
        public async Task<IActionResult> ProfileDetails(string userID)
        {
            if(_signInManager.IsSignedIn(User))
            {
                var thisUser = await _manager.GetUserAsync(User);

                if(thisUser.Id == userID)
                {
                    return RedirectToAction("Profile", "Profiles");
                }
            }

            var user = await _mediator.Send(new GetProfileByIdCommand { UserID = userID });
            var questions = _mediator.Send(new GetAnsweredQuestionCommand { UserID = user.Id });

            var model = new UserProfileModel
            {
                Questions = questions.Result,
                User = user
            };

            return View("ProfileDetails", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile([FromForm] EditProfileViewModel newUser)
        {
            var user = await _manager.GetUserAsync(User);

            await _mediator.Send(new EditProfileCommand
            {
                Model = newUser
            });

            return RedirectToAction("Profile", "Profiles");
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _manager.GetUserAsync(User);
            var questions = _mediator.Send(new GetAnsweredQuestionCommand { UserID = user.Id });

            var model = new UserProfileModel
            {
                Questions = questions.Result,
                User = user
            };
            return View(model);
        }
    }
}