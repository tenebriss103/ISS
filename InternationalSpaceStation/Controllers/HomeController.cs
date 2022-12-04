using InternationalSpaceStation.Models;
using InternationalSpaceStation.Models.ISS_people;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InternationalSpaceStation.Controllers
{
    public class HomeController : Controller
    {
        
        public Root Position()
        {
            WebRequest request = WebRequest.Create("http://api.open-notify.org/iss-now.json");
            WebResponse response = request.GetResponse();
            JsonTextReader reader = new JsonTextReader(new StreamReader(response.GetResponseStream()));
            reader.SupportMultipleContent = true;
            JsonSerializer serializer = new JsonSerializer();          
            return serializer.Deserialize<Root>(reader);

        }
        public RootList ListOfPeople()
        {
            WebRequest request = WebRequest.Create("http://api.open-notify.org/astros.json");
            WebResponse response = request.GetResponse();
            JsonTextReader reader = new JsonTextReader(new StreamReader(response.GetResponseStream()));
            reader.SupportMultipleContent = true;
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<RootList>(reader);

        }

        public  DateTime UnixTimeStampToDateTime()
        {
            int unixTimeStamp = Position().timestamp;
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public IEnumerable<PeopleItem> GetPeople()
        {
            
            var people = ListOfPeople().people;
            return people.Where(p => p.craft == "ISS").ToList();
           
        }
        public int SumOfPeople()
        {

            
            return GetPeople().Count();

        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
