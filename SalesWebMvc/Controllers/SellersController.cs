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
        // quando é usado readonly para previne que
        //essa dependencia não seja alterada 

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
             
            return View(list);
        }
         public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Create(Saller seller)
        {
            _sellerService.Insert(seller);

            return RedirectToAction(nameof(Index));
        }
    }
}