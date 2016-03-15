using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Domain.Model;
using SqlHelperLibrary;
using System.Data;
using System.Data.SqlClient;
using FinalProject.Data.Interfaces;
namespace FinalProject.Data.Repository
{
   public class ProductDalRepository:IProductRepository
    {
         public const string conString ="Data Source=DESKTOP-NBMCBR7\\SQLEXPRESS;Initial Catalog=MulticuisinDb;Integrated Security=True";

         public ProductDalRepository()
         { }
         public IList<Product> GetProduct()
        {
            List<Product> List = new List<Product>();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Product";
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype);
            if(reader!=null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product item = new Product();
                        item.ProductId = int.Parse(reader["ProductId"].ToString());
                        item.Title = reader["Title"].ToString();
                        item.Brand = reader["Brand"].ToString();
                        item.Description = reader["Description"].ToString();
                        item.CategoryId = int.Parse(reader["CategoryId"].ToString());
                        item.ImageUrl = reader["ImageUrl"].ToString();
                        item.Price = double.Parse(reader["Price"].ToString());
                        List.Add(item);
                    }
                }
            }
            return List;
        }

        public Product GetProductById(int ProductId)
        {
            Product item = new Product();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Product Where ProductId=@productId";
            SqlParameter sqlParam1 = new SqlParameter("@productId", ProductId);
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype,sqlParam1);
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item.ProductId = int.Parse(reader["ProductId"].ToString());
                    item.Title = reader["Title"].ToString();
                    item.Brand = reader["Brand"].ToString();
                    item.Description = reader["Description"].ToString();
                    item.CategoryId = int.Parse(reader["CategoryId"].ToString());
                    item.ImageUrl = reader["ImageUrl"].ToString();
                    item.Price = double.Parse(reader["Price"].ToString());                   
                }
                reader.Close();
            }
            return item;
        }

        public int InsertProduct(Product product)
        {
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "INSERT INTO Product(Title,Brand,Description,CategoryId,ImageUrl,Price) values (@title,@brand,@description,@categoryId,@imageUrl,@price)";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@title", product.Title);
            SqlParameter sqlParam2 = new SqlParameter("@brand",product.Brand);
            SqlParameter sqlParam3 = new SqlParameter("@description", product.Description);
            SqlParameter sqlParam4 = new SqlParameter("@categoryId", product.CategoryId);
            SqlParameter sqlParam5 = new SqlParameter("@imageUrl", product.ImageUrl);
            SqlParameter sqlParam6 = new SqlParameter("@price", product.Price);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3, sqlParam4, sqlParam5, sqlParam6);           
            return status;
        }

        public int DeleteProduct(int productId)
        {
            
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Delete from Product where ProductId=@productId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@productId",productId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);
            return status;
        }

        public int UpdateProduct(Product product)
        {
            
            SqlHelper sqlh = new SqlHelper(conString);
            string query = " Update Product Set Title=@title,Brand=@brand,Description=@description,CategoryId=@categoryId,ImageUrl=@imageUrl,Price=@price where ProductId=@productId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@title", product.Title);
            SqlParameter sqlParam2 = new SqlParameter("@brand", product.Brand);
            SqlParameter sqlParam3 = new SqlParameter("@description", product.Description);
            SqlParameter sqlParam4 = new SqlParameter("@categoryId", product.CategoryId);
            SqlParameter sqlParam5 = new SqlParameter("@imageUrl", product.ImageUrl);
            SqlParameter sqlParam6 = new SqlParameter("@price",product.Price);
            SqlParameter sqlParam7 = new SqlParameter("@productId", product.ProductId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3, sqlParam4, sqlParam5, sqlParam6,sqlParam7);
            return status;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
       
    }
}
