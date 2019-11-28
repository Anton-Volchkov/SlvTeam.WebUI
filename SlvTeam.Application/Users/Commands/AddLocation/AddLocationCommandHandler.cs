using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using MediatR;
using Newtonsoft.Json;
using WebApplication1.Data;

namespace SlvTeam.Application.Users.Commands.AddLocation
{
    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        private const string EndPoint = "https://nominatim.openstreetmap.org/reverse?format=json";

        private const string UserAgent =
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36";

        public AddLocationCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            var response = await EndPoint.AllowAnyHttpStatus().SetQueryParam("lat", $"{request.Lat}")
                                         .SetQueryParam("lon", $"{request.Lon}").WithHeader("User-Agent", UserAgent)
                                         .GetAsync();

            if(!response.IsSuccessStatusCode)
            {
                return false;
            }

            var Location = JsonConvert.DeserializeObject<LocationModel>(await response.Content.ReadAsStringAsync());

            var textInfo = new CultureInfo("ru-RU").TextInfo;
            var capitaliedText = textInfo.ToTitleCase(textInfo.ToLower(Location.DisplayName));

            request.User.Location = capitaliedText;
            await _db.SaveChangesAsync();

            return true;
        }
    }
}