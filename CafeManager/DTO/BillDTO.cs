using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class BillDTO
    {
        public BillDTO(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
        }

        public BillDTO(DataRow row)
        {
            this.ID = (int)row["IdBill"]; 
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if(dateCheckOutTemp.ToString() !="")
             this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = (int)row["StatusBill"];
        }

        private int status;

        private int Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime? dateCheckOut;

        private DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private DateTime? dateCheckIn;

        private DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
