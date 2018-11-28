using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DetailBillDAO
    {
        public static bool IsExistDrinkInBillByIDBill(int id)
        {
            //load bảng chi tiết hóa đơn theo mã hóa đơn
            List<DetailBillDTO> listDetailBil = new List<DetailBillDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.DETAILBILL where IDBill = " + id);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static void InsertDetailBill(int idbill, int iddrink, int quantity)
        {
            DataProvider.Instance.ExcuteNonQuery("Exec USP_InsertBillInfo @idbill , @iddrink , @quantity ", new object[] { idbill, iddrink, quantity });
        }

        public static int GetQuantityDrink(int idbill, int idDrink)
        {
            //load bảng chi tiết hóa đơn theo mã hóa đơn
            List<DetailBillDTO> listDetailBil = new List<DetailBillDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.DETAILBILL as de where IDBill = " + idbill + " and IDDrink = " + idDrink);
            if (data.Rows.Count > 0)
            {
                DetailBillDTO debill = new DetailBillDTO(data.Rows[0]);
                return debill.Quantity ;
            }
            return 0 ;
        }
        public static int GetTotalDetailBillByIDBill(int idbill)
        {
            //load bảng chi tiết hóa đơn theo mã hóa đơn
            List<DetailBillDTO> listDetailBil = new List<DetailBillDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.DETAILBILL as de where IDBill = " + idbill);
            if (data.Rows.Count > 0)
            {
                int tongtien = 0;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DetailBillDTO debill = new DetailBillDTO(data.Rows[i]);
                    tongtien += debill.Quantity;
                }
                return tongtien;
            }
            return 0;
        }
        public static void DeleteOneDrink(int idbill, int iddrink)
        {
            string query = "Exec USP_DeleteDeTailBill @idbill , @iddrink "; // mà có idbill rồi thì nó xác nhân cái id bill rồi xóa mak.... Hỏi lại xóa bill hay xóa sản phẩm trong bill....xóa sản phẩm trong detail bill...1 sản phẩm có ở mấy cái bill...1 bill có bao nhiêu sản phẩm...hết call video

            // Quên nữa xóa sản phẩm trong bill không phải xóa bill
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { idbill, iddrink });
        }

        public static int IsExistDrink(int id)
        {
            string query = "select de.IDDrink from DETAILBILL as de where de.IDDrink = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["IDDrink"].ToString());
            }
            return -1;
        }

        public static bool IsExistDrinkByIDBillAndIDDrink(int idbill, int idDrink)
        {
            //load bảng chi tiết hóa đơn theo mã hóa đơn
            List<DetailBillDTO> listDetailBil = new List<DetailBillDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.DETAILBILL as de where IDBill = " + idbill + " and IDDrink = " + idDrink);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsEmpty(int idbill)
        {
            //load bảng chi tiết hóa đơn theo mã hóa đơn
            List<DetailBillDTO> listDetailBil = new List<DetailBillDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from dbo.DETAILBILL as de where IDBill = " + idbill);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static List<DetailBillDTO> GetListDrinkByIDBill(int idBill)
        {
            List<DetailBillDTO> lstDrink = new List<DetailBillDTO>();
            string query = "select * from DETAILBILL WHERE IDBill = @idBill";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { idBill });
            foreach (DataRow item in data.Rows)
            {
                DetailBillDTO detail = new DetailBillDTO(item);
                lstDrink.Add(detail);
            }
            return lstDrink;
        }
        
 }
}
