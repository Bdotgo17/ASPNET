﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repo;
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);

            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = repo.GetProduct(id);

            if(product == null)
            {
                return View("Products not found");
            }

            return View(product);
        }
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProdcut(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();

            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }
    }
}
