using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailBillDTO
    {
        public DetailBillDTO()
        {

        }
        public DetailBillDTO(int idbill,int iddrink,int quantity)
        {
            this.IDbill = idbill;
            this.IDDrink = iddrink;
            this.Quantity = quantity;
        }
        public DetailBillDTO(DataRow row)
        {
            this.IDbill = (int)row["IDBill"];
            this.IDDrink = (int)row["IDDrink"];
            this.Quantity = (int)row["Quantity"];
        }

        private int iDbill;

        public int IDbill
        {
            get { return iDbill; }
            set { iDbill = value; }
        }
        private int iDDrink;

        public int IDDrink
        {
            get { return iDDrink; }
            set { iDDrink = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
