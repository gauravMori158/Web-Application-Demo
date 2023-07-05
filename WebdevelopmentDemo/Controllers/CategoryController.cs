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
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo1)
        {
            this.categoryRepo = categoryRepo1;
                
        }


        // GET: Category
        public async Task<IActionResult> Index()
        {
            var category = categoryRepo.GetAll();
              return  View(category);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || categoryRepo.GetAll()  == null)
            {
                return NotFound();
            }

            var category =  categoryRepo.GetById(id);   
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
            categoryRepo.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || categoryRepo.GetAll() == null)
            {
                return NotFound();
            }

            var category = categoryRepo.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                   categoryRepo.EditCategory(category);
                
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || categoryRepo.GetAll() == null)
            {
                return NotFound();
            }

            var category = categoryRepo.GetById(id) ;
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (categoryRepo.GetAll() == null)
            {
                return Problem("Entity set 'DbContextClass.Categories'  is null.");
            }
            var category =  categoryRepo.GetById(id) ;
            if (category != null)
            {
                categoryRepo.DeleteCategory(id);
            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}
