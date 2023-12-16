using AjaxTemp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AjaxTemp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Example> list = new List<Example>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            if (!list.Any())
            {
                list.Add(new() { Name = "ex 1", Price = 10});
                list.Add(new() { Name = "ex 2", Price = 20 });
                list.Add(new() { Name = "ex 3", Price = 30});
                list.Add(new() { Name = "ex 4", Price = 40 });
            }
        }

        public IActionResult Index()
        {
            return View(list);
        }

        public IActionResult GetData(string id)
        {
            var mydata = list.Find(x => x.Id == id);
            return PartialView("_ExamplePatialView", mydata);
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
