using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using WebApplication1.Data;

namespace SlvTeam.WebUI.Helpers
{
    public class PhotoDecoder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        public PhotoDecoder(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }

        public async Task Execute()
        {
            var users = _db.Users.Where(x => x.ImageBytes != null).ToArray();

            foreach(var user in users)
            {
                using (FileStream fs = new System.IO.FileStream(_appEnvironment.WebRootPath+"/UserImages/"+user.ImageName, FileMode.OpenOrCreate))
                {
                    fs.Write(user.ImageBytes, 0, user.ImageBytes.Length);
                }
            }

        }
    }
}
