using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalSpaceStation.Models.ISS_people
{
    public class RootList
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("number")]
        public string number { get; set; }

        [JsonProperty("people")]
        public List<PeopleItem> people { get; set; }

        public override string ToString()
        {
            return $"Peple: {people}, Number:{number}  ";
        }
    }
}
