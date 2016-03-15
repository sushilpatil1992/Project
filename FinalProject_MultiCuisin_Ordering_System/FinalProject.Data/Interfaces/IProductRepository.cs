using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Domain.Model;
namespace FinalProject.Data.Interfaces
{
    public interface IProductRepository
        {
            IList<Product> GetProduct();
            Product GetProductById(int productId);
            int InsertProduct(Product product);
            int DeleteProduct(int productId);
            int UpdateProduct(Product product);
            void Save();
        }
}
