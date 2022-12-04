using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalSpaceStation.Models.ISS_people
{
    public class PeopleItem
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("craft")]
        public string craft { get; set; }
    }
}
