using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CalculatorMvc.Controllers
{
    public class CalculatorClientController : Controller
    {
        private readonly HttpClient _client;  //HttpClient -used to send reqst and rspnc to the external api.

        //httpclientfactory intrfce help to create and manage instance
        public CalculatorClientController(IHttpClientFactory factory) //constructor
        {
            _client = factory.CreateClient("CalculatorApi"); //instance for api
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Add(int a, int b)
        {
            var result = await _client.GetFromJsonAsync<int>($"api/calculator/add?a={a}&b={b}");
            ViewBag.Result = result;
            ViewBag.Operation = $"{a} + {b} =";
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Subtract(int a, int b)
        {
            var result = await _client.GetFromJsonAsync<int>($"api/calculator/subtract?a={a}&b={b}");
            ViewBag.Result = result;
            ViewBag.Operation = $"{a} - {b} =";
            return View("Index");
        }

    }
}
