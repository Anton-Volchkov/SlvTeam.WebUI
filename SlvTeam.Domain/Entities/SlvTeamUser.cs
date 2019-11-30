using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SlvTeam.Domain.Entities
{
    public class SlvTeamUser : IdentityUser
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Address { get; private set; }

        public string RegisterDate { get; set; }

        public byte[] ImageBytes { get; set; } = new byte[0];

        public string ImageName { get; set; } = "NoPhoto.png";

        public string AboutAs { get; set; }

        public string Location { get; set; }

        public bool IsSlvTeam { get; set; }

        public ICollection<Message> Messages { get; set; }

        public SlvTeamUser()
        {
            RegisterDate = DateTime.Now.ToString("G");
        }


        public SlvTeamUser(string login, string firstName, string lastName, string phone, string email,
                           string address, string aboutAs, string photoName = "NoPhoto.png") : this()
        {
            SetUserName(login);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhone(phone);
            SetEmail(email);
            SetAddress(address);
            AboutAs = aboutAs;
            ImageName = photoName;

            //TODO: reg time
        }

        public void SetAboutAs(string info)
        {
            if(string.IsNullOrWhiteSpace(info))
            {
                throw new ArgumentException("Inbfo about as is empty", nameof(info));
            }

            AboutAs = info;
        }


        public void SetUserName(string login)
        {
            if(string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("login is empty", nameof(login));
            }

            UserName = login;
        }

        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName is empty", nameof(firstName));
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName is empty", nameof(lastName));
            }

            LastName = lastName;
        }

        public void SetPhone(string phone) //TODO: валидация на номер
        {
            if(string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("phone is empty", nameof(phone));
            }

            PhoneNumber = phone;
        }

        public void SetEmail(string email) //TODO: валидация на почту
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("phone is empty", nameof(email));
            }

            Email = email;
        }

        public void SetAddress(string address)
        {
            if(string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("address is empty", nameof(address));
            }

            Address = address;
        }
    }
}