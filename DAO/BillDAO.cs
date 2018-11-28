using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace DAO
{
    public class BillDAO
    {
        public static List<BillDTO> GetAllListBill()
        {
            List<BillDTO> lstBill = new List<BillDTO>();
            string query = "select * from BILL WHERE Status = 1";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillDTO detail = new BillDTO(item);
                lstBill.Add(detail);
            }
            return lstBill;
        }

        public static int GetIDBillNoPaymentByIDTable(int idTable)
        {
            DataTable data= DataProvider.Instance.ExcuteQuery("Select * from dbo.BILL where IDTable = " + idTable + " and Status = 0");//chưa thanh toán
            if(data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public static void InsertBill(DateTime ThoiGian, double TongTien, int Employ, int idTable)
        {
            try
            {
                string query = "Exec USP_InsertBill @thoigian , @tongtien , @employ , @idtable ";
                DataProvider.Instance.ExcuteNonQuery(query, new object[] { ThoiGian, TongTien, Employ, idTable });
            }
        catch
            {

            }
        }

        public static int GetIDBillMax()
        {
            string re = DataProvider.Instance.ExcuteScalar("select Max(id) from dbo.BILL").ToString();
            if (re != "")
                return Convert.ToInt32(re);
            return 1;
        }

        public static void UpdatetBill(int id, double totalbill,DateTime datetime, int employ)
        {
            string query = "Exec USP_UpdateBill @idbill , @totalbill , @datetime , @employ";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, totalbill, datetime , employ });
        }
        public static void DeleteBill(int idbill)
        {
            DataProvider.Instance.ExcuteNonQuery("Exec USP_Deletebill @idbill ", new object[] { idbill });
        }

        public static List<BillDTO> GetListBillInAboutTime(DateTime ThoiGianTu, DateTime ThoiGianDen)
        {
            List<BillDTO> lstBill = new List<BillDTO>();
            string query = "select * from BILL WHERE CreateDay BETWEEN @thoigiantu and @thoigianden and Status = 1";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { ThoiGianTu, ThoiGianDen });
            foreach (DataRow item in data.Rows)
            {
                BillDTO detail = new BillDTO(item);
                lstBill.Add(detail);
            }
            return lstBill;
        }


        public static bool IsExistAccountInBill(int user)
        {
            //load bảng chi tiết hóa đơn theo mã hóa đơn
            DataTable data = DataProvider.Instance.ExcuteQuery("select ID from BILL where Employ = "+ user);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
