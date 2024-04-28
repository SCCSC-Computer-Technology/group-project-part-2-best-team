using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsWebApplication.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace SportsWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory clientFactory;

        public UserController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            clientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ShowUsers()
        {
            string uri;

            ViewData["Title"] = "All Users";
            uri = "api/Users/";

            HttpClient client = clientFactory.CreateClient(name: "SportsAPI");

            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            IEnumerable<UserViewModel>? model = await response.Content.ReadFromJsonAsync<IEnumerable<UserViewModel>>();
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
