using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class FoodDTO
    {
        public FoodDTO(int id, string name, int categoryID, float price)
        {
            this.ID = id;
            this.NameFood = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public FoodDTO(DataRow row)
        {
            this.ID = (int)row["IdFood"];
            this.NameFood = row["NameFood"].ToString();
            this.CategoryID = (int)row["IdCategory"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;

        public string NameFood
        {
            get { return name; }
            set { name = value; }
        }

        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
