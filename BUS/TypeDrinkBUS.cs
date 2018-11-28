using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public  class TypeDrinkBUS
    {
        public static List<TypeDrinkDTO> GetAllListTypeDrink()
        {
            return TypeDrinkDAO.GetAllListTypeDrink();
        }

        public static List<TypeDrinkDTO> GetListTypeDrinkWithStatusOne(int status)
        {
            return TypeDrinkDAO.GetListTypeDrinkWithStatusOne(status);
        }

        public static bool InsertTypeDrink(TypeDrinkDTO tydr)
        {
            return TypeDrinkDAO.InsertTypeDrink(tydr);
        }

        public static bool UpdateTypeDrink(TypeDrinkDTO tydr)
        {
            return TypeDrinkDAO.UpdateTypeDrink(tydr);
        }

        public static bool DeleteTypeDrink(TypeDrinkDTO tydr)
        {
            return TypeDrinkDAO.DeleteTypeDrink(tydr);
        }

        public static int GetIDTypeDrinkMax()
        {
            return TypeDrinkDAO.GetIDTypeDrinkMax();
        }
    }
}
