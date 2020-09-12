using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
   public class SellersController : Controller
   {
      private readonly SellerService _sellerService;              // Dependência
      private readonly DepartmentService _departmentService;      // Dependência

      public SellersController(SellerService sellerService, DepartmentService departmentService)
      {
         _sellerService = sellerService;                 // Injeta a dependência no construtor
         _departmentService = departmentService;         // Injeta a dependência no construtor
      }

      public IActionResult Index()                    // Ação do Controller
      {
         var list = _sellerService.FindAll();         // que acessa o Model e
         return View(list);                           // encaminha a lista resultante para a View
      }

      public IActionResult Create()
      {
         var departments = _departmentService.FindAll();
         var viewModel = new SellerFormViewModel { Departments = departments };
         return View(viewModel);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Create(Seller seller)
      {
         _sellerService.Insert(seller);
         return RedirectToAction(nameof(Index));
      }

      public IActionResult Delete(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var obj = _sellerService.FindById(id.Value);    // o ".value" é usado porque o id é opcional
         if (obj == null)
         {
            return NotFound();
         }

         return View(obj);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Delete(int id)
      {
         _sellerService.Remove(id);
         return RedirectToAction(nameof(Index));
      }

      public IActionResult Details(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var obj = _sellerService.FindById(id.Value);    // o ".value" é usado porque o id é opcional
         if (obj == null)
         {
            return NotFound();
         }

         return View(obj);
      }




   }
}
