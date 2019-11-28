using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SlvTeam.Domain.Models
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

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
        [Display(Name = "О вас")]
        public string AboutAs { get; set; }


        public IFormFile ImagePath { get; set; }
    }
}