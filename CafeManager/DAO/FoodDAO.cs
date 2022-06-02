using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<FoodDTO> GetFoodByCategoryID(int id)
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "select * from dbo.Food where IdCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }

            return list;
        }
        public List<FoodDTO> GetListFood()
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "select * from Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }

            return list;
        }

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.Food ( NameFood, IdCategory, Price )VALUES  ( N'{0}', {1}, {2})", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET NameFood = N'{0}', IdCategory = {1}, Price = {2} WHERE IdFood = {3}", name, id, price, idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            BillDetailDAO.Instance.DeleteBillDetailByFoodID(idFood);

            string query = string.Format("Delete dbo.Food where IdFood = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
