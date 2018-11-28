using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TableDTO
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string nameTable;

        public string NameTable
        {
            get { return nameTable; }
            set { nameTable = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public TableDTO()
        {

        }
        public TableDTO(int id, string nametable, int status)
        {
            this.ID = id;
            this.NameTable = nametable;
            this.status = status;
        }
        public TableDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NameTable = row["NameTable"].ToString();
            this.Status = (int)row["Status"];
        }
    }
}
