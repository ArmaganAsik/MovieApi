using Microsoft.AspNetCore.Mvc;
using MovieApi.DTO.DTOs.AdminReviewDTOs;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReviewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ListReviews(int page = 1, int pageSize = 10)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7253/api/Reviews?page={page}&pageSize={pageSize}");

            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<AdminResultReviewDto> values = JsonConvert.DeserializeObject<List<AdminResultReviewDto>>(jsonData);

                int totalCount = Convert.ToInt32(responseMessage.Headers.GetValues("X-Total-Count").FirstOrDefault() ?? "0");

                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalCount = totalCount;
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                return View(values);
            }

            return View();
        }
    }
}
