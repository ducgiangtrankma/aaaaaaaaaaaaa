using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class DrinkBUS
    {
        public static List<DrinkDTO> GetListDrinkByIDTypeDrink(int id, int status)
        {
            return DrinkDAO.GetListDrinkByIDTypeDrink(id, status);
        }

        public static List<DrinkDTO> GetListDrinkByID(int id)
        {
            return DrinkDAO.GetListDrinkByID(id);
        }
        public static List<DrinkDTO> GetAllListDrink()
        {
            return DrinkDAO.GetAllListDrink();
        }
        public static bool InsertDrink(DrinkDTO sp)
        {
            return DrinkDAO.InsertDrink(sp);
        }
        public static int GetIDDrinkMax()
        {
            return DrinkDAO.GetIDDrinkMax();
        }
        public static bool DeleteDrink(DrinkDTO sp)
        {
            return DrinkDAO.DeleteDrink(sp);
        }
        public static bool UpdateDrink(DrinkDTO sp)
        {
            return DrinkDAO.UpdateDrink(sp);
        }
        public static int GetIDTypeDrinkByIDDrink(int id)
        {
            return DrinkDAO.GetIDTypeDrinkByIDDrink(id);
        }
        public static List<DrinkDTO> GeDrinkByName(string name)
        {
            return DrinkDAO.GeDrinkByName(name);
        }
    }
}
