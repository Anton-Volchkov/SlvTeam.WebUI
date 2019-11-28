using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SlvTeam.Domain.Entities;
using WebApplication1.Data;

namespace WebApplication1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<SlvTeamUser> _signInManager;
        private readonly UserManager<SlvTeamUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ApplicationDbContext _db;


        public RegisterModel(
            UserManager<SlvTeamUser> userManager,
            SignInManager<SlvTeamUser> signInManager,
            ILogger<RegisterModel> logger, IWebHostEnvironment appEnvironment, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _appEnvironment = appEnvironment;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Имя")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Имя пользователя")]
            public string Login { get; set; }

            [Required]
            [Display(Name = "Телефон")]
            public string Phone { get; set; }

            [Required]
            [Display(Name = "Адрес")]
            public string Adress { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Электронная почта")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} должен содержать минимум {2} и максимум {1} символов.",
                MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Повторите пароль")]
            [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "О вас")]
            public string AboutAs { get; set; }


            [Display(Name = "Фотография")]
            public IFormFile ImagePath { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if(ModelState.IsValid)
            {
                if(!(Input.ImagePath is null))
                {
                    var path = "/UserImages/" + Input.ImagePath.FileName;
                    using(var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await Input.ImagePath.CopyToAsync(fileStream);
                    }
                }

                var user = new SlvTeamUser(Input.Login, Input.FirstName, Input.LastName, Input.Phone, Input.Email,
                                           Input.Adress, Input.AboutAs);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if(result.Succeeded)
                {
                    _logger.LogInformation("Пользователь успешно создан.");

                    await _signInManager.SignInAsync(user, false);

                    if(!(Input.ImagePath is null))
                    {
                        var path = "/UserImages/" + Input.ImagePath.FileName;
                        using(var binaryReader = new BinaryReader(Input.ImagePath.OpenReadStream()))
                        {
                            var imageData = binaryReader.ReadBytes((int) Input.ImagePath.Length);

                            user.Image = imageData;

                            await _userManager.UpdateAsync(user);
                        }
                    }

                    return LocalRedirect(returnUrl);
                }

                foreach(var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}