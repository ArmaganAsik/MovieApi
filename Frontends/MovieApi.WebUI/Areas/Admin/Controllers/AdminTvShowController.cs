using Microsoft.AspNetCore.Mvc;
using MovieApi.DTO.DTOs.AdminTvShowDTOs;
using Newtonsoft.Json;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTvShowController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminTvShowController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListTvShows()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7253/api/TvShows");

            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<AdminResultTvShowDto> values = JsonConvert.DeserializeObject<List<AdminResultTvShowDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public IActionResult CreateTvShow()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTvShow(AdminCreateTvShowDto adminCreateTvShowDto)
        {
            string jsonData = JsonConvert.SerializeObject(adminCreateTvShowDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7253/api/TvShows", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListTvShows", "AdminTvShow", new { area = "Admin" });
            }
            return View();
        }
    }
}
