using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class MenuDTO
    {
        public MenuDTO(string nameFood, int amount, float price, float totalPrice = 0)
        {
            this.NameFood = nameFood;
            this.Amount = amount;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public MenuDTO(DataRow row)
        {
            this.NameFood = row["NameFood"].ToString();
            this.Amount = (int)row["Amount"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }

        private string nameFood;

        public string NameFood
        {
            get { return nameFood; }
            set { nameFood = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

       private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private float totalPrice;

        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }


    }
}
