using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class TableDTO
    {
        public TableDTO(int id, string name, string status) // tạo hàm dựng
        {
            this.IdFoodTable = id;
            this.NameTable = name;
            this.Status = status;
        }

        public TableDTO(DataRow row) // hàm dựng để xử lý DataRow
        {
            this.IdFoodTable = (int)row["IdTableFood"];
            this.NameTable = row["NameTable"].ToString();
            this.Status = row["StatusTable"].ToString();
        }

        private int iD;

        public int IdFoodTable
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;

        public string NameTable
        {
            get { return name; }
            set { name = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
     }
}
