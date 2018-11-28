using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MenuDTO
    {
        public MenuDTO(int ID,string NameDrink, int Quantity, double PriceBasic, int IDDrink, double TotalPrice = 0)
        {
            this.ID = ID;
            this.NameDrink = NameDrink;
            this.Quantity = Quantity;
            this.PriceBasic = PriceBasic;
            this.TotalPrice = TotalPrice;
            this.IdDrink = IDDrink;
          
        }
        public MenuDTO(DataRow row)
        {
            
            this.ID = (int)row["ID"];
            this.NameDrink = row["NameDrinks"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.PriceBasic = (double)row["PriceBasic"];
            this.TotalPrice = (double)row["TotalPrice"];
            this.IdDrink = (int)row["IDDrink"];
          

        }
      
        private int idDrink;

        public int IdDrink
        {
            get { return idDrink; }
            set { idDrink = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string nameDrink;

        public string NameDrink
        {
            get { return nameDrink; }
            set { nameDrink = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private double priceBasic;

        public double PriceBasic
        {
            get { return priceBasic; }
            set { priceBasic = value; }
        }
        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
    }
}
