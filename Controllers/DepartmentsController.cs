using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{

    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Departments";

            List<Department> list = new();
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            //enviar dados do controller para a view
            return View(list);
        }
    }
}