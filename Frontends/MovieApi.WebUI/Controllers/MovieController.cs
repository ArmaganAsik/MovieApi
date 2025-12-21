using Microsoft.AspNetCore.Mvc;
using MovieApi.DTO.DTOs.MovieDTOs;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";

            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7253/api/Movies");

            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultMovieDTO> values = JsonConvert.DeserializeObject<List<ResultMovieDTO>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> MovieDetail(int id)
        {
            id = 0;
            return View();
        }
    }
}
