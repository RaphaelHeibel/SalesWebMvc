using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Models.ViewModels;
using src.Services;

namespace src.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        #region GET
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            SellerFormViewModel viewModel = new() { Departments = _departmentService.ListAll() };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
                return NotFound();

            return View(obj);
        }
        #endregion

        #region POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //O framework sabe que o faz a instancia do DepartamentId automaticamente
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}