using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO // <=> Model : Định dạng các đối tượng.Lớp trung gian vận chuyển Data - Mô hình hóa CSDL lên
    // Tên Bản -> Tên Lớp
    // Cột -> Thuộc tính
    // Dữ liệu -> Đối tượng
    // Là Lớp dùng chung
{
    public class AccountDTO
    {
        public AccountDTO()
        {

        }
        public AccountDTO(int ID, string Password,string Name, string PassPort,string PlaceOfBirth, string Telephone, string Address, int Right, int Status)
        {
            this.ID = ID;
            this.PassWord = PassWord;
            this.Name = Name;
            this.PassPort = PassPort;
            this.PlaceOfBirth = PlaceOfBirth;
            this.Telephone = Telephone;
            this.Address = Address;
            this.Right = Right;
            this.Status = Status;
        }
        public AccountDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.PassWord = row["Pass"].ToString();
            this.Name = row["Name"].ToString();
            this.PassPort = row["PassPort"].ToString();
            this.PlaceOfBirth= row["PlaceOfBirth"].ToString();
            this.Telephone = row["Telephone"].ToString();
            this.Address = row["Address"].ToString();
            this.Right = (int)row["Rights"];
            this.Status = (int)row["Status"];
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string passWord;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string passPort;
        public string PassPort
        {
          get { return passPort; }
          set { passPort = value; }
        }public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        private string placeOfBirth;

        public string PlaceOfBirth
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }
        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private int right;

        public int Right
        {
            get { return right; }
            set { right = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
