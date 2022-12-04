using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalSpaceStation.Models
{
    public class Root
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("timestamp")]
        public int timestamp { get; set; }

        [JsonProperty("iss_position")]
        public Iss_position iss_position { get; set; }
    }
}
