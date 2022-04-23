﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModel;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // quando é usado readonly para previne que
        //essa dependencia não seja alterada 

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(
            SellerService sellerService,
            DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task <IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
             
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var departments =await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel {Departments =departments };
            return View(viewModel);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create(Saller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
           await _sellerService.InsertAsync(seller);

            return RedirectToAction(nameof(Index));
        }

        public  async Task<IActionResult> Delete(int? id)
        {
             if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
             if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id)
        {
            try
            {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
            }
            catch(IntergrityException ex)
            {
              return RedirectToAction(nameof(Error), new { message = ex.Message });
            }

            }

        public  async Task<IActionResult> Details(int? id)
        {
              if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
               return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel {Seller = obj,Departments =departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, Saller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments =await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem"});
            }
            try
            {
              await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
       
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}