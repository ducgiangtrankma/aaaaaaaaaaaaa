using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DrinkDAO
    {
        public static List<DrinkDTO> GetListDrinkByIDTypeDrink(int id,int status)
        {
            List<DrinkDTO> listdrink = new List<DrinkDTO>();
            string query = "";
            if (id == 0)
                query = "select top 10 * from DRINK where Status = " + status + " and DRINK.IDTypeDink NOT IN (select ID from TYPEDRINK where Status = 0)";
            else
            {
                if(status == -1)
                    query = "select * from DRINK where IDTypeDink = " + id;
                else 
                query = "select * from DRINK where IDTypeDink = " + id + " and Status = " + status;
            }
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                listdrink.Add(drink);
            }
            return listdrink;
        }

        public static int GetIDTypeDrinkByIDDrink(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select d.IDTypeDink from dbo.DRINK as d where IDTypeDink = " + id);//chưa thanh toán
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["IDTypeDink"].ToString());
            }
            return -1;
        }

        public static List<DrinkDTO> GetAllListDrink()
        {
            List<DrinkDTO> listdrink = new List<DrinkDTO>();
            string query = "select * from DRINK";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                listdrink.Add(drink);
            }
            return listdrink;
        }

        public static List<DrinkDTO> GetListDrinkByID(int id)
        {
            List<DrinkDTO> listdrink = new List<DrinkDTO>();
            string query = "select * from DRINK where ID = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                listdrink.Add(drink);
            }
            return listdrink;
        }

        public static bool InsertDrink(DrinkDTO sp)
        {
            
            string query = "Exec USP_InsertDrink @name , @pricebasic , @saleprice , @status , @idtype ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { sp.NameDrinks, sp.PriceBasic, sp.SalePrice, sp.Status, sp.IDTypeDrink }) == 1)
            {
                return true;
            }
            return false ;
        }

        public static bool UpdateDrink(DrinkDTO sp)
        {

            string query = "Exec USP_UpdateDrink @id , @name , @pricebasic , @saleprice , @status , @idtype ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { sp.ID, sp.NameDrinks, sp.PriceBasic, sp.SalePrice, sp.Status, sp.IDTypeDrink }) == 1)
            {
                return true;
            }
            return false;
        }

        public static int GetIDDrinkMax()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetIDDrink");
            if (data.Rows.Count > 0)
            {
                    return  Convert.ToInt32(data.Rows[0]["ID"].ToString()) + 1;
            }
            return 1;
        }

        public static bool DeleteDrink(DrinkDTO sp)
        {

            string query = "Exec USP_DeleteByDrink @id ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { sp.ID }) == -1)
            {
                return false;
            }
            return true;
        }
        public static List<DrinkDTO> GeDrinkByName(string name)
        {
            List<DrinkDTO> listdrink = new List<DrinkDTO>();
            string query = String.Format("SELECT * FROM dbo.DRINK WHERE dbo.fChuyenCoDauThanhKhongDau(NameDrinks) LIKE N'%' + dbo.fChuyenCoDauThanhKhongDau(N'{0}') + '%' and DRINK.IDTypeDink NOT IN (select ID from TYPEDRINK where Status = 0)", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                listdrink.Add(drink);
            }
            return listdrink;
        }
    }
}
