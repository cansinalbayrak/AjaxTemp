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
        [HttpPost]
        public IActionResult Update(Example example)
        {
            var ex = list.FirstOrDefault(e => e.Id == example.Id);

            for (int i = 0;i<list.Count;i++) 
            {
                if (list[i].Id == ex.Id)
                {
                    list[i] = example;
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string id)
        {
            var ex = list.FirstOrDefault(e=>e.Id == id);
            list.Remove(ex);
            return RedirectToAction("Index");
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
