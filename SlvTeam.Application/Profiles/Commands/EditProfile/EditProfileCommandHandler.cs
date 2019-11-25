﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SlvTeam.Domain.Entities;

namespace SlvTeam.Application.Profiles.Commands.EditProfile
{
    class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, SlvTeamUser>
    {
        private readonly UserManager<SlvTeamUser> _manager;
        private readonly IHostingEnvironment _appEnvironment;
        public EditProfileCommandHandler(UserManager<SlvTeamUser> manager, IHostingEnvironment appEnvironment)
        {
            _manager = manager;
            _appEnvironment = appEnvironment;
        }
        public async Task<SlvTeamUser> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var User = await _manager.FindByIdAsync(request.Model.Id);

            if(request.Model.ImagePath != default(IFormFile) && User.ImagePath != request.Model.ImagePath.FileName)
            {
                var path = "/UserImages/" + request.Model.ImagePath.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await request.Model.ImagePath.CopyToAsync(fileStream);
                }

                User.ImagePath = request.Model.ImagePath.FileName;
            }
           
            User.SetFirstName(request.Model.FirstName);
            User.SetLastName(request.Model.LastName);
            User.SetAddress(request.Model.Adress);
            User.SetEmail(request.Model.Email);
            User.SetPhone(request.Model.Phone);
            User.SetAboutAs(request.Model.AboutAs);
            await _manager.UpdateAsync(User);
             

            return User;
        }
    }
}
