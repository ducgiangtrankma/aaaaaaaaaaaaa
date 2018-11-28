using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public  class MenuDAO
    {
       public static List<MenuDTO> GetListMenuByIDTable(int id)
       {
           List<MenuDTO> listmenu = new List<MenuDTO>();
           string query = "select de.IDDrink, d.ID, d.NameDrinks, de.Quantity, d.PriceBasic, de.Quantity*d.PriceBasic as TotalPrice, Status = 0 from dbo.BILL as bi, dbo.DETAILBILL as de, dbo.DRINK as d where de.IDBill = bi.ID and de.IDDrink = d.ID and bi.Status = 0 and bi.IDTable = " + id;//0 chưa thanh toán / 1 đã thanh toán rồi.
           DataTable data = DataProvider.Instance.ExcuteQuery(query);
           foreach(DataRow item in data.Rows)
           {
               MenuDTO menu = new MenuDTO(item);
               listmenu.Add(menu);
           }
           return listmenu;
       }
       public static List<MenuDTO> GetListMenuByIDBill(int idBill)
       {
           List<MenuDTO> listmenu = new List<MenuDTO>();
           string query = "select de.IDDrink, d.ID, d.NameDrinks, de.Quantity, d.PriceBasic, de.Quantity*d.PriceBasic as TotalPrice, Status = 0 from dbo.BILL as bi, dbo.DETAILBILL as de, dbo.DRINK as d where de.IDBill = bi.ID and de.IDDrink = d.ID and bi.Status = 0 and de.IDBill = " + idBill;//0 chưa thanh toán / 1 đã thanh toán rồi.
           DataTable data = DataProvider.Instance.ExcuteQuery(query);
           foreach (DataRow item in data.Rows)
           {
               MenuDTO menu = new MenuDTO(item);
               listmenu.Add(menu);
           }
           return listmenu;
       }

       public static List<MenuDTO> GetReviewBill(int idBill)
       {
           List<MenuDTO> listmenu = new List<MenuDTO>();
           string query = "select de.IDDrink, d.ID, d.NameDrinks, de.Quantity, d.PriceBasic, de.Quantity*d.PriceBasic as TotalPrice, Status = 0 from dbo.BILL as bi, dbo.DETAILBILL as de, dbo.DRINK as d where de.IDBill = bi.ID and de.IDDrink = d.ID and bi.Status = 1 and de.IDBill = " + idBill;//0 chưa thanh toán / 1 đã thanh toán rồi.
           DataTable data = DataProvider.Instance.ExcuteQuery(query);
           foreach (DataRow item in data.Rows)
           {
               MenuDTO menu = new MenuDTO(item);
               listmenu.Add(menu);
           }
           return listmenu;
       }
       
    }
}
