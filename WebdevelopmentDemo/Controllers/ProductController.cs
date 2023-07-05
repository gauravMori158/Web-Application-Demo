using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebdevelopmentDemo.Interface;
using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductRepo productRepo;
        public ProductController(IProductRepo productRepo1)
        {
                productRepo = productRepo1;
        }

        public async Task<IActionResult> Index()
        {
            var ProductList = productRepo.GetAll();
           
            return View( ProductList);
        }

       
        public async Task<IActionResult> Details(int id)
        {


            var product =  productRepo.GetById (id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Roles ="Admin,User")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(productRepo.GetAll().Select(x=>x.Category) , "Id", "Name");
            return View();
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> Create(  Product product)
        { 
                productRepo.AddProduct(product );
                return RedirectToAction(nameof(Index));
            
            ViewData["CategoryId"] = new SelectList(productRepo.GetAll().Select(x => x.Category), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [Authorize (Roles ="Admin")]

        public async Task<IActionResult> Edit(int id)
        {
           

            var product = productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(productRepo.GetAll().Select(x => x.Category), "Id", "Name", product.CategoryId);
            return View(product);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 productRepo.EditProduct(product);
                
              
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(productRepo.GetAll().Select(x => x.Category), "Id", "Name", product.CategoryId);
            return View(product);
        }
        [Authorize (Roles ="Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || productRepo.GetById(id)== null)
            {
                return NotFound();
            }

            var product = productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (productRepo.GetAll() == null)
            {
                return Problem("Entity set 'DbContextClass.Products'  is null.");
            }
            var product = productRepo.GetById(id);
            if (product != null)
            {
                productRepo.DeleteProduct(id);
            }
            
        
            return RedirectToAction(nameof(Index));
        }
 
    }
}
