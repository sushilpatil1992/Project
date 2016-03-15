using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using FinalProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _CategoryService;
       public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View( _CategoryService.GetCategory());
        }

        
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(CategoryViewModel categoryVm)
        {
            if(ModelState.IsValid)
            {
                Category category = new Category();
                category = copyCategory(categoryVm);
                _CategoryService.InsertCategory(category);
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            CategoryViewModel cvm = new CategoryViewModel();
            Category c = new Category();
            c=_CategoryService.GetCategoryByID(id);
            cvm = copyCategory(c);
            return View(cvm);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel cvm)
        {
            if(ModelState.IsValid)
            {
                Category c = new Category();
                c = copyCategory(cvm);
                _CategoryService.UpdateCategory(c);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if(id>0)
            {
                _CategoryService.DeleteCategory(id);
                return RedirectToAction("Index");               
            }
            else
            {
                ModelState.AddModelError("", "Please Enter Id");
            }
            return RedirectToAction("Index");
        }
        public Category copyCategory(CategoryViewModel c)
        {
            Category cat=new Category();
            cat.CategoryId = c.CategoryId;
            cat.Title = c.Title;
            return cat;
        }
        public CategoryViewModel copyCategory(Category c)
        {
            CategoryViewModel cat = new CategoryViewModel();
            cat.CategoryId = c.CategoryId;
            cat.Title = c.Title;
            return cat;
        }
    }

    

}