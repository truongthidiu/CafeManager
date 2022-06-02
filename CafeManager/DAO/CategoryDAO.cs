using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<CategoryDTO> GetListCategory()
        {
            List<CategoryDTO> list = new List<CategoryDTO>();

            string query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                CategoryDTO category = new CategoryDTO(item);
                list.Add(category);
            }

            return list;
        }
        public CategoryDTO GetCategoryByID(int id)
        {
            CategoryDTO category = null;

            string query = "select * from FoodCategory where IdFoodCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new CategoryDTO(item);
                return category;
            }

            return category;
        }
        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT dbo.FoodCategory (NameCategory) VALUES  ( N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(int idCategory, string name)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET NameCategory = N'{0}' WHERE IdFoodCategory = {1}", name, idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int idCategory)
        {
            string query = string.Format("Delete dbo.FoodCategory where IdFoodCategory = {0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
