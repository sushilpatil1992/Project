using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using FinalProject.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FinalProject.Data.Repository;
namespace FinalProject.Web.Controllers
{
    public class HomeController : Controller
    {
       readonly IProductService _ProductService=null;
        readonly ICategoryService _CategoryService;
       public HomeController(IProductService productService,ICategoryService categoryService)
       {
           _CategoryService = categoryService;
           _ProductService = productService;
       }
        
        public ActionResult Index(string category)
        {
            
            IList<Domain.Model.Product> p;
            ProductDalRepository productDal = new ProductDalRepository();
            ProductService productService = new ProductService(productDal);
            p = productService.GetProducts();
            if(!(String.IsNullOrEmpty(category)))
            {
                return View(productService.GetProducts().ToList().Where(c => c.Title == category));
            }
            return View(p);
        }
        

        public ActionResult About()
        {            
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}
