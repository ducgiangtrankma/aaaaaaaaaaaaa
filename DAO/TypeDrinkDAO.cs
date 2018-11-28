using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class TypeDrinkDAO
    {
        public static List<TypeDrinkDTO> GetListTypeDrinkWithStatusOne(int status)
        {
            List<TypeDrinkDTO> listtype = new List<TypeDrinkDTO>();// 0 ẩn , 1 hiện
            string query = "select * from TYPEDRINK where Status = " + status;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                TypeDrinkDTO type = new TypeDrinkDTO(item);
                listtype.Add(type);
            }
            return listtype;
        }

        public static List<TypeDrinkDTO> GetAllListTypeDrink()
        {
            List<TypeDrinkDTO> listtypedrink = new List<TypeDrinkDTO>();
            string query = "select * from TYPEDRINK";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TypeDrinkDTO typedrink = new TypeDrinkDTO(item);
                listtypedrink.Add(typedrink);
            }
            return listtypedrink;
        }

        public static bool InsertTypeDrink(TypeDrinkDTO tydr)
        {
            string query = "Exec USP_InsertTypeDrink @nametype , @status ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { tydr.Nametype, tydr.Status }) == 1)
            {
                return true;
            }
            return false;
        }

        public static bool UpdateTypeDrink(TypeDrinkDTO tydr)
        {
            string query = "Exec USP_UpdateTypeDrink @id , @nametype , @status ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { tydr.ID, tydr.Nametype, tydr.Status }) == 1)
            {
                return true;
            }
            else
                return false;
        }

        public static bool DeleteTypeDrink(TypeDrinkDTO tydr)
        {
            string query = "Exec USP_DeleteTypeDrink @id";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { tydr.ID }) == 1)
            {
                return true;
            }
            return false;
        }

        public static int GetIDTypeDrinkMax()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetIDTypeDrink");//chưa thanh toán
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["ID"].ToString()) + 1;
            }
            return -1;
        }
        
    }
}
