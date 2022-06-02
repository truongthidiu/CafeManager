using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> tableList = new List<TableDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            // để chuyển DataTable sang List<TableDTO> thì ta cho chuyển từng row thành list

            foreach (DataRow item in data.Rows) // DataRow đã được tạo trong TableDTO
            {
                TableDTO table = new TableDTO(item);
                tableList.Add(table);
            }

            return tableList;
        }

        

        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT dbo.TableFood (NameTable) VALUES  ( N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(int idTable, string name)
        {
            string query = string.Format("UPDATE dbo.TableFood SET NameTable = N'{0}' WHERE IdTableFood = {1}", name, idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int idTable)
        {
            string query = string.Format("Delete dbo.TableFood where IdTableFood = {0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
