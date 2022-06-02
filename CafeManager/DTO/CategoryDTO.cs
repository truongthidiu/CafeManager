using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO(int id, string name)
        {
            this.IdFoodCategory = id;
            this.NameCategory = name;
        }

        public CategoryDTO(DataRow row)
        {
            this.IdFoodCategory = (int)row["IdFoodCategory"];
            this.NameCategory = row["NameCategory"].ToString();
        }

        private int iD;

        public int IdFoodCategory
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;

        public string NameCategory
        {
            get { return name; }
            set { name = value; }
        }

        
    }
}
