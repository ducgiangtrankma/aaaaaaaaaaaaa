using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DrinkDTO
    {
        public DrinkDTO()
        {
           
        }
        public DrinkDTO(int ID, string NameDrinks, double PriceBasic, double SalePrice, int Status, int IDTypeDrink)
        {
            this.ID = ID;
            this.NameDrinks = NameDrinks;
            this.PriceBasic = PriceBasic;
            this.SalePrice = SalePrice;
            this.Status = Status;
            this.IDTypeDrink = IDTypeDrink;
        }
        public DrinkDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NameDrinks = row["NameDrinks"].ToString();
            this.PriceBasic = (double)row["PriceBasic"];
            this.SalePrice = (double)row["SalePrice"];
            this.Status = (int)row["Status"];
            this.IDTypeDrink = (int)row["IDTypeDink"];
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string nameDrinks;

        public string NameDrinks
        {
            get { return nameDrinks; }
            set { nameDrinks = value; }
        }
        private double priceBasic;

        public double PriceBasic
        {
            get { return priceBasic; }
            set { priceBasic = value; }
        }
        private double salePrice;

        public double SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int iDTypeDrink;

        public int IDTypeDrink
        {
            get { return iDTypeDrink; }
            set { iDTypeDrink = value; }
        }
    }
}
