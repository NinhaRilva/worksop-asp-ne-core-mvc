using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Service;

namespace SalesWebMvc.Controllers
{

    public class SellersController : Controller
    {
    private readonly SellerService _sallerService;
        public IActionResult Index()
        {
            var list = _sallerService;
            return View();
        }
    }
}