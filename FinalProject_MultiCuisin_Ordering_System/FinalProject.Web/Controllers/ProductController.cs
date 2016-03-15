using FinalProject.Data.Repository;
using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Web.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService productService;
        readonly ICategoryService _CategoryService;
        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _CategoryService = categoryService;
            this.productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {

            return View(productService.GetProducts());
        }
        [Authorize(Roles="Admin")]
        public ActionResult AddProduct()
        {
            IList<Category> categories = _CategoryService.GetCategory();
            ViewBag.Categories=categories.Select((
                c=>new SelectListItem
                {
                    Text=c.Title,
                    Value=c.CategoryId.ToString()
                }));            
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddProduct(Product product,HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    string dbpath = "Images\\" + file.FileName;
                    file.SaveAs(path);
                    product.ImageUrl = dbpath;
                    ProductDalRepository productDal = new ProductDalRepository();
                    ProductService productService = new ProductService(productDal);
                    productService.InsertProduct(product);
                    return (RedirectToAction("Index", "Home"));
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }           
            return View();
        }

        public ActionResult Details(int id)
        {
            Product p = new Product();
            p=productService.GetProductByID(id);
            TempData["Product"] = p;
            return View(p);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Product p = new Product();
            p = productService.GetProductByID(id);
            FinalProject.Web.Models.Product product = new FinalProject.Web.Models.Product();
            product = copyProduct(p);
            IList<Category> categories = _CategoryService.GetCategory();
            ViewBag.Categories = categories.Select((
                c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.CategoryId.ToString()
                }));
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(FinalProject.Web.Models.Product vmProduct, HttpPostedFileBase file)
        {
            Product product = new Product();
            product = copyProduct(vmProduct);
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"),
                                                   Path.GetFileName(file.FileName));
                        string dbpath = "Images\\" + file.FileName;
                        file.SaveAs(path);
                        product.ImageUrl = dbpath;                        
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }
                productService.UpdateProduct(product);
            }
            return (RedirectToAction("Index", "Home"));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            int status = productService.DeleteProduct(id);
            if(status>0)
            {
                return (RedirectToAction("Index", "Home"));
            }
            else
            {
                return (RedirectToAction("Details", "Product"));
            }

            
        }
        public ActionResult AddToCart()
        {
            Session["OrderCount"] = 1;
            return View();
        }

        public FinalProject.Web.Models.Product copyProduct(Product product)
        {
            FinalProject.Web.Models.Product vmProduct = new FinalProject.Web.Models.Product();
            vmProduct.ProductId = product.ProductId;
            vmProduct.Title = product.Title;
            vmProduct.Brand = product.Brand;
            vmProduct.CategoryId = product.CategoryId;
            vmProduct.Description = product.Description;
            vmProduct.ImageUrl = product.ImageUrl;
            vmProduct.Price = product.Price;
            return vmProduct;
        }

        public Product copyProduct(FinalProject.Web.Models.Product vmProduct)
        {
            Product product = new Product();
           product.ProductId=vmProduct.ProductId;
           product.Title=vmProduct.Title;
           product.Brand=vmProduct.Brand;
           product.CategoryId=vmProduct.CategoryId;
           product.Description=vmProduct.Description;
           product.ImageUrl=vmProduct.ImageUrl;
           product.Price = vmProduct.Price;
            return product;
        }
    }
}