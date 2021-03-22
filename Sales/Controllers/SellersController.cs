﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Services;
using Sales.Models;

namespace Sales.Controllers
{
    public class SellersController : Controller
    {

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
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            // return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }
    }
}
