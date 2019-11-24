using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlvTeam.Application.Users.Commands.AddLocation
{
    public partial class LocationModel
    {
        [JsonProperty("place_id")]
        public long PlaceId { get; set; }

        [JsonProperty("licence")]
        public string Licence { get; set; }

        [JsonProperty("osm_type")]
        public string OsmType { get; set; }

        [JsonProperty("osm_id")]
        public long OsmId { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("boundingbox")]
        public string[] Boundingbox { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("department_store")]
        public string DepartmentStore { get; set; }

        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }

        [JsonProperty("road")]
        public string Road { get; set; }

        [JsonProperty("neighbourhood")]
        public string Neighbourhood { get; set; }

        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        [JsonProperty("city_district")]
        public string CityDistrict { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
       
        public string Postcode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
