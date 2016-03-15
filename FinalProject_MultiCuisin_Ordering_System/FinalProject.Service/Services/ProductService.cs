using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _ProductRepository;
        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        public IList<Product> GetProducts()
        {
            return _ProductRepository.GetProduct();
        }

        public Product GetProductByID(int productId)
        {
            return _ProductRepository.GetProductById(productId);
        }

        public int InsertProduct(Product product)
        {
            int status = _ProductRepository.InsertProduct(product);
            return status;
        }

        public int DeleteProduct(int productId)
        {
            int status = _ProductRepository.DeleteProduct(productId);
            return status;
        }

        public int UpdateProduct(Product product)
        {
            int status = _ProductRepository.UpdateProduct(product);
            return status;
        }

        public void Save()
        {
            _ProductRepository.Save();
        }
    }
    
}
