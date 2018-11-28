using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TypeDrinkDTO
    {
        public TypeDrinkDTO()
        {

        }
        public TypeDrinkDTO(int ID, string NameType, int Status)
        {
            this.ID = ID;
            this.Nametype = Nametype;
            this.Status = Status;
        }
        public TypeDrinkDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Nametype = row["NameType"].ToString();
            this.Status = (int)row["Status"];
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string nametype;

        public string Nametype
        {
            get { return nametype; }
            set { nametype = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        
    }
}
