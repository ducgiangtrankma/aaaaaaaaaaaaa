using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        public BillDTO(int ID, DateTime CreateDay, double Total,int idtable,int Employ, int Status)
        {
            this.ID = ID;
            this.CreateDay = CreateDay;
            this.Total = Total;
            this.idtable = idtable;
            this.Employ = Employ;
            this.Status = Status;
        }
        public BillDTO (DataRow row)
        {
            this.ID = (int)row["ID"];
            this.CreateDay = Convert.ToDateTime(row["CreateDay"]);
            this.Total = (double)row["TotalBill"];
            this.idtable = (int)row["IDTable"];
            this.Employ = (int)row["Employ"];
            this.Status = (int)row["Status"];
        }
        private int idtable;

        public int Idtable
        {
            get { return idtable; }
            set { idtable = value; }
        }


        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        private DateTime createDay;

        public DateTime CreateDay
        {
            get { return createDay; }
            set { createDay = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private int employ;

        public int Employ
        {
            get { return employ; }
            set { employ = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
