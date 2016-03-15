using FinalProject.Domain.Model;
using SqlHelperLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Data.Repository;
using FinalProject.Service.Services;
using FinalProject.Data.Interfaces;
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////*********************Payment*******************************************/
            //Payment f = new Payment();
            //IList<Payment> foods;
            //IPaymentRepository dal = new PaymentDalRepository();
            //PaymentService productService = new PaymentService(dal);
            ////Insert
            //f.OrderId = 1;
            //f.PaymentId = 1;
            //f.PaymentMode = PaymentMode.CreditCard;
            //f.Amount = 123.23;
            //f.Date = System.DateTime.Now;
            //int status = productService.InsertPayment(f);
            //if (status > 0)
            //{
            //    Console.WriteLine("Inserted Succesfully");
            //}

            ////SelectById
            //f = productService.GetPaymentByID(1);
            //Console.WriteLine(f.Amount);
            //Console.WriteLine("SelectbyId Succesfully");
            ////SelectAll
            //foods = productService.GetPayments();
            //foreach (Payment p in foods)
            //{
            //    Console.WriteLine(p.Amount);
            //}
            //Console.WriteLine("SelectAll Succesfully");
            ////Update
            //f.OrderId = 1;
            //f.PaymentId = 1;
            //f.PaymentMode = PaymentMode.CreditCard;
            //f.Amount = 123.23;
            //f.Date = System.DateTime.Now;

            //int ustatus = productService.UpdatePayment(f);
            //if (ustatus > 0)
            //{
            //    Console.WriteLine("Updated Succesfully");
            //}

            //int id = 1;
            //int dstatus = productService.DeletePayment(id);
            //if (dstatus > 0)
            //{
            //    Console.WriteLine("Delted Succesfully");
            //}
            //Console.Read();
            ////********************* Order*******************************************/
            //Order f = new Order();
            //IList<Order> foods;
            //IOrderRepository dal = new OrderDalRepository();
            //OrderService productService = new OrderService(dal);
            ////Insert
            //f.OrderId = 1;
            //f.OrderDate = System.DateTime.Now;
            //f.CustomerId = 1;
            //f.Amount = 123;
            //int status = productService.InsertOrder(f);
            //if (status > 0)
            //{
            //    Console.WriteLine("Inserted Succesfully");
            //}

            ////SelectById
            //f = productService.GetOrderByID(1);
            //Console.WriteLine(f.Amount);
            //Console.WriteLine("SelectbyId Succesfully");
            ////SelectAll
            //foods = productService.GetOrders();
            //foreach (Order p in foods)
            //{
            //    Console.WriteLine(p.Amount);
            //}
            //Console.WriteLine("SelectAll Succesfully");
            ////Update
            //f.OrderId = 1;
            //f.OrderDate = System.DateTime.Now;
            //f.CustomerId = 1;
            //f.Amount = 123;

            //int ustatus = productService.UpdateOrder(f);
            //if (ustatus > 0)
            //{
            //    Console.WriteLine("Updated Succesfully");
            //}

            //int id = 1;
            //int dstatus = productService.DeleteOrder(id);
            //if (dstatus > 0)
            //{
            //    Console.WriteLine("Delted Succesfully");
            //}
            //Console.Read();

            ////********************* OrderDetails*******************************************/
            //OrderDetails f = new OrderDetails();
            //IList<OrderDetails> foods;
            //IOrderDetailsRepository dal = new OrderDetailsDalRepository();
            //OrderDetailsService productService = new OrderDetailsService(dal);
            ////Insert
            //f.OdetailsId = 1;
            //f.OrderId = 1;
            //f.Price = 123.123;
            //f.ProductId = 1;
            //f.Quantity = 12;


            //int status = productService.InsertOrderDetails(f);
            //if (status > 0)
            //{
            //    Console.WriteLine("Inserted Succesfully");
            //}

            ////SelectById
            //f = productService.GetOrderDetailsById(1);
            //Console.WriteLine(f.Quantity);
            //Console.WriteLine("SelectbyId Succesfully");
            ////SelectAll
            //foods = productService.GetOrderDetails();
            //foreach (OrderDetails p in foods)
            //{
            //    Console.WriteLine(p.Quantity);
            //}
            //Console.WriteLine("SelectAll Succesfully");
            ////Update
            //f.OdetailsId = 1;
            //f.OrderId = 1;
            //f.Price = 123.123;
            //f.ProductId = 1;
            //f.Quantity = 12;

            //int ustatus = productService.UpdateOrderDetails(f);
            //if (ustatus > 0)
            //{
            //    Console.WriteLine("Updated Succesfully");
            //}

            //int id = 1;
            //int dstatus = productService.DeleteOrderDetails(id);
            //if (dstatus > 0)
            //{
            //    Console.WriteLine("Delted Succesfully");
            //}
            //Console.Read();
            ////*********************Category*******************************************/
            //Category f = new Category();
            //IList<Category> foods;
            //ICategoryRepository dal = new CategoryDalRepository();
            //CategoryService productService = new CategoryService(dal);
            ////Insert
            //f.CategoryId = 1;
            //f.Title = "Pizza";
            //int status = productService.InsertCategory(f);
            //if (status > 0)
            //{
            //    Console.WriteLine("Inserted Succesfully");
            //}

            ////SelectById
            //f = productService.GetCategoryByID(1);
            //Console.WriteLine(f.Title);
            //Console.WriteLine("SelectbyId Succesfully");
            ////SelectAll
            //foods = productService.GetCategory();
            //foreach (Category p in foods)
            //{
            //    Console.WriteLine(p.Title);
            //}
            //Console.WriteLine("SelectAll Succesfully");
            ////Update
            //f.CategoryId = 1;
            //f.Title = "Pizza";

            //int ustatus = productService.UpdateCategory(f);
            //if (ustatus > 0)
            //{
            //    Console.WriteLine("Updated Succesfully");
            //}

            //int id = 1;
            //int dstatus = productService.DeleteCategory(id);
            //if (dstatus > 0)
            //{
            //    Console.WriteLine("Delted Succesfully");
            //}
            //Console.Read();

            ////*********************Customer*******************************************/
            //Customer f = new Customer();
            //IList<Customer> foods;
            //ICustomerRepository dal = new CustomerDalRepository();
            //CustomerService productService = new CustomerService(dal);
            ////Insert
            //f.CustomerId = 1;
            //f.FirstName = "amit";
            //f.LastName = "shinde";
            //f.UserId = 1;
            //f.Adress = "Pune";
            //int status = productService.InsertCustomer(f); 
            //if(status>0)
            //{
            //    Console.WriteLine("Inseted Succesfully");
            //}

            ////SelectById
            //f = productService.GetCustomerByID(1);
            //Console.WriteLine(f.FirstName);
            //Console.WriteLine("SelectbyId Succesfully");
            ////SelectAll
            //foods = productService.GetCutomers();
            //foreach (Customer p in foods)
            //{
            //    Console.WriteLine(p.FirstName );
            //}
            //Console.WriteLine("SelectAll Succesfully");
            ////Update
            //f.CustomerId = 1;
            //f.FirstName = "amit";
            //f.LastName = "shinde";
            //f.UserId = 1;
            //f.Adress = "Pune";

            //int ustatus = productService.UpdateCustomer(f);
            //if (ustatus > 0)
            //{
            //    Console.WriteLine("Updated Succesfully");
            //}

            //int id = 1;
            //int dstatus = productService.DeleteCustomer(id);
            //if (dstatus > 0)
            //{
            //    Console.WriteLine("Delted Succesfully");
            //}
            //Console.Read();
            ////*********************Product*******************************************/
            //Product f = new Product();
            //IList<Product> foods;
            //IProductRepository dal = new ProductDalRepository();
            //ProductService productService = new ProductService(dal);
            ////Insert
            //f.Title = "Burger";
            //f.Description = "Yummy";
            //f.Brand = "Domnos";
            //f.Price = 123.123;
            //f.CategoryId = 1;
            //f.ImageUrl = "C:\a\a\a";
            //int status = productService.InsertProduct(f);
            //if (status > 0)
            //{
            //    Console.WriteLine("Inseted Succesfully");
            //}

            ////SelectById
            //f = productService.GetProductByID(1);
            //Console.WriteLine(f.Brand);
            //Console.WriteLine("SelectbyId Succesfully");
            ////SelectAll
            //foods = productService.GetProducts();
            //foreach (Product p in foods)
            //{
            //    Console.WriteLine(p.Brand);
            //}
            //Console.WriteLine("SelectAll Succesfully");
            ////Update
            //f.ProductId = 1;
            //f.CategoryId = 1;
            //f.Title = "Burger";
            //f.Description = "Yummy";
            //f.Brand = "Dominos";
            //f.Price = 123.123;
            //f.CategoryId = 1;
            //f.ImageUrl = "C:\a\a\a";

            //int ustatus = productService.UpdateProduct(f);
            //if (ustatus > 0)
            //{
            //    Console.WriteLine("Updated Succesfully");
            //}

            //int id = 1;
            //int dstatus = productService.DeleteProduct(id);
            //if (dstatus > 0)
            //{
            //    Console.WriteLine("Delted Succesfully");
            //}
            //Console.Read();

           
        }
    }
}
