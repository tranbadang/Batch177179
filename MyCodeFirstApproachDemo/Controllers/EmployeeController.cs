using Microsoft.AspNetCore.Mvc;
using MyCodeFirstApproachDemo.Models;

namespace MyCodeFirstApproachDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee em)
        {
            return View(em);
        }
    }
}
