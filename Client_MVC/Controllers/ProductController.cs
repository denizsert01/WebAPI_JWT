using Client_MVC.Models;
using Client_MVC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client_MVC.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly HttpClient _httpClient;

        static string jwtToken = "";

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            if(jwtToken != "")
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", jwtToken);
                var urunler = await _httpClient.GetFromJsonAsync<List<Product>>("http://localhost:5113/api/Product");
                return View(urunler);
            }
            return Content("Yetkisiz kullanım...");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _httpClient.PostAsJsonAsync("http://localhost:5113/api/Login", login);

            if(result.IsSuccessStatusCode)
            {
                string jwt = await result.Content.ReadAsStringAsync();
                jwtToken = "Bearer " + jwt;                

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(login);
        }
    }
}
