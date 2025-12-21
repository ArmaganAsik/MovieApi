using Microsoft.AspNetCore.Mvc;
using MovieApi.DTO.DTOs.UserRegisterDTOs;

namespace MovieApi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(CreateUserRegisterDto createUserRegisterDto)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
