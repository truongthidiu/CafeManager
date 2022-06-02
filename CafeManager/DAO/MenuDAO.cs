using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<MenuDTO> GetListMenuByTable(int id)
        {
            List<MenuDTO> listMenu = new List<MenuDTO>();

            string query = "SELECT f.NameFood, bd.Amount, f.Price, f.Price*bd.Amount AS TotalPrice FROM dbo.BillDetail AS bd, dbo.Bill AS b, dbo.Food AS f WHERE bd.IdBill = b.IdBill AND bd.IdFood = f.IdFood AND b.StatusBill = 0 AND b.IdTable =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
