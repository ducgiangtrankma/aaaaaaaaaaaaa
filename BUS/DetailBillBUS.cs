using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class DetailBillBUS
    {
        public static bool IsExistDrinlInBillByIDBill(int id)
        {
            return DetailBillDAO.IsExistDrinkInBillByIDBill(id);
        }
        public static List<DetailBillDTO> GetListDrinkByIDBill(int idBill)
        {
            return DetailBillDAO.GetListDrinkByIDBill(idBill);
        }
        
        public static void InsertDetailBill(int idbill, int iddrink, int quantity)
        {
            DetailBillDAO.InsertDetailBill(idbill, iddrink, quantity);
        }
        public static int GetQuantityDrink(int idbill, int idDrink)
        {
           return DetailBillDAO.GetQuantityDrink(idbill, idDrink);
        }
        public static void DeleteOneDrink(int idbill, int iddrink)
        {
            DetailBillDAO.DeleteOneDrink(idbill,iddrink);
        }
        public static int IsExistDrink(int id)
        {
            return DetailBillDAO.IsExistDrink(id);  
        }
        public static int GetTotalDetailBillByIDBill(int idBill)
        {
            return DetailBillDAO.GetTotalDetailBillByIDBill(idBill);
        }
        public static bool IsExistDrinkByIDBillAndIDDrink(int idbill, int idDrink)
        {
            return DetailBillDAO.IsExistDrinkByIDBillAndIDDrink(idbill, idDrink);
        }
        public static bool IsEmpty(int idbill)
        {
            return DetailBillDAO.IsEmpty(idbill);
        }
   
    }
}
