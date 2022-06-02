using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class BillDetailDTO
    {
        public BillDetailDTO(int id, int idBill, int idFood, int amount)
        {
            this.ID = id;
            this.IdBill = idBill;
            this.IdFood = idFood;
            this.Amount = amount;
        }

        public BillDetailDTO(DataRow row)
        {
            this.ID = (int)row["IdBillDetail"];
            this.IdBill = (int)row["IdBill"];
            this.IdFood = (int)row["IdFood"];
            this.Amount = (int)row["Amount"];
        }

        private int amount;

        private int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private int idFood;

        private int IdFood
        {
            get { return idFood; }
            set { idFood = value; }
        }

        private int idBill;

        private int IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }

        private int iD;

        private int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
