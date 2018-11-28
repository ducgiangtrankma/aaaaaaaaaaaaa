using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class BillBUS
    {
        public static List<BillDTO> GetAllListBill()
        {
            return BillDAO.GetAllListBill();
        }
        public static List<BillDTO> GetListBillInAboutTime(DateTime from,DateTime to)
        {
            return BillDAO.GetListBillInAboutTime(from,to);
        }
        public static int GetIDBillNoPaymentByIDTable(int id)
        {
            return BillDAO.GetIDBillNoPaymentByIDTable(id);
        }
        public static void InsertBill(DateTime ThoiGian, double TongTien, int Employ, int idTable)
        {
            BillDAO.InsertBill(ThoiGian,TongTien,Employ,idTable);
        }
        public static int GetIDBillMax()
        {
            return BillDAO.GetIDBillMax();
        }
        public static void UpdatetBill(int id,double totalbill,DateTime time,int employ)
        {
            BillDAO.UpdatetBill(id, totalbill,time,employ);
        }
        public static void DeleteBill(int idbill)
        {
            BillDAO.DeleteBill(idbill);
        }

        public static bool IsExistAccountInBill(int user)
        {
            return BillDAO.IsExistAccountInBill(user);
        }
        
    }
}
