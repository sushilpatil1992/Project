using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Interfaces
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product GetProductByID(int productId);
        int InsertProduct(Product product);
        int DeleteProduct(int productId);
        int UpdateProduct(Product product);
        void Save();
       
    }
}
