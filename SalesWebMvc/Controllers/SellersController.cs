using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
   public class SellersController : Controller
   {
      private readonly SellerService _sellerService;

      public SellersController(SellerService sellerService)
      {
         _sellerService = sellerService;
      }

      public IActionResult Index()                    // Ação do Controller
      {
         var list = _sellerService.FindAll();         // que acessa o Model e
         return View(list);                           // encaminha a lista resultante para a View
      }

      public IActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Create(Seller seller)
      {
         _sellerService.Insert(seller);
         return RedirectToAction(nameof(Index));
      }
   }
}
