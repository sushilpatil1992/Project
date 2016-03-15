using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using SqlHelperLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Repository
{
    public class CategoryDalRepository:ICategoryRepository
    {
         public const string conString ="Data Source=DESKTOP-NBMCBR7\\SQLEXPRESS;Initial Catalog=MulticuisinDb;Integrated Security=True";

         public CategoryDalRepository()
         { }
         public IList<Category> GetCategory()
        {
            List<Category> List = new List<Category>();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Category";
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype);
            if(reader!=null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Category item = new Category();
                        item.CategoryId = int.Parse(reader["CategoryId"].ToString()); 
                        item.Title = reader["Title"].ToString();                        
                        List.Add(item);
                    }
                }
            }
            return List;
        }

        public Category GetCategoryById(int categoryId)
        {
            Category item = new Category();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Category Where CategoryId=@categoryId";
            SqlParameter sqlParam1 = new SqlParameter("@categoryId", categoryId);
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype,sqlParam1);
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item.CategoryId = int.Parse(reader["CategoryId"].ToString());
                    item.Title = reader["Title"].ToString();   
                }
                reader.Close();
            }
            return item;
        }

        public int InsertCategory(Category Category)
        {
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "INSERT INTO Category(Title) values (@title)";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@title", Category.Title);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);           
            return status;
        }

        public int DeleteCategory(int categoryId)
        {
            
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Delete from Category where CategoryId=@categoryId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@categoryId",categoryId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);
            return status;
        }

        public int UpdateCategory(Category Category)
        {
            
            SqlHelper sqlh = new SqlHelper(conString);
            string query = " Update Category Set Title=@title where CategoryId=@categoryId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@title", Category.Title);
            SqlParameter sqlParam2 = new SqlParameter("@categoryId", Category.CategoryId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1,sqlParam2);
            return status;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

       
    }
}
