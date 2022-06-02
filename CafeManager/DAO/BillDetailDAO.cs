using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAO
{
    public class BillDetailDAO
    {
        private static BillDetailDAO instance;

        public static BillDetailDAO Instance
        {
            get { if (instance == null) instance = new BillDetailDAO(); return BillDetailDAO.instance; }
            private set { BillDetailDAO.instance = value; }
        }

        private BillDetailDAO() { }

        public void DeleteBillDetailByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE FROM dbo.BillDetail WHERE IdFood = " + id);
        }

        public void InsertBillDetail(int idBill, int idFood, int amount)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillDetail @idBill , @idFood , @amount", new object[] { idBill, idFood, amount });
        }

    }
}
