using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;
using Newtonsoft.Json;
using EntitiesClassLibrary;
using System.Collections.Generic;

namespace WebClient.Controllers
{
    [Route("/test")]
    public class HttpClientController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> ClientSample()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:21910/weatherforecast");

            var json = await response.Content.ReadAsStringAsync();

            var items = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(json);

            // Note: List<WeatherForecast> ==> List<string> (Summary)
            var words = string.Join(", ", items.Select(x => x.Summary).Distinct());


            var model = new MyModel {
                StatusCode = response.StatusCode,
                ServerSideDuration = response.Headers.GetValues("action-duration")
                    .First().ToString(),
                Count = items.Count(),
                ListOfWords = words
            };

            return View(model);
        }

    }
}
