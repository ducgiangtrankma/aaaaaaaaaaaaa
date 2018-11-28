using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO // Lớp kết nối cơ sở dữ liệu - DataAccesObject// Thực hiện toàn bộ tương tác với CSDL
{
    public class AccountDAO
    {
        public static bool IsLogin(int username, string password)
        {
            string query = "Select * from dbo.ACCOUNT where ID = @user and Pass = @pass ";
            DataTable resuft = DataProvider.Instance.ExcuteQuery(query,new object[]{username,password});
            return resuft.Rows.Count > 0;
        }
        public static int GetRightByAccount(int user)// lấy ra chức vụ của tài khoản theo id
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select ac.Rights from dbo.ACCOUNT as ac where ID = @user ",new object[] { user });//chưa thanh toán
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["Rights"].ToString());
            }
            return -1;
        }
        
        public static string GetNameByAccount(int user)// Lấy ra tên của chủ tài khoản theo ID
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select ac.Name from dbo.ACCOUNT as ac where ID = @user ", new object[] { user });//chưa thanh toán
            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["Name"].ToString();
            }
            return "Chưa có nhân viên";
        }
        public static List<AccountDTO> GetListAccountOnStatus(int status)// tại list tài khoản theo trạng thái (mở )
        {
            List<AccountDTO> listaccount = new List<AccountDTO>();
            string query = "select * from ACCOUNT where Status = "+ status;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                listaccount.Add(account);
            }
            return listaccount;
        }
        public static List<AccountDTO> GetAllListAccount()// Lấy hết danh sách tài khoản
        {
            List<AccountDTO> listaccount = new List<AccountDTO>();
            string query = "select * from ACCOUNT";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                AccountDTO account = new AccountDTO(item);
                listaccount.Add(account);
            }
            return listaccount;
        }

        public static AccountDTO GetAccount(int user)// Lấy tài khoản theo ID
        {
            string query = "select * from ACCOUNT where  ID = @user ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { user });
            AccountDTO account = new AccountDTO();
            if (data.Rows.Count > 0)
            {
                return new AccountDTO(data.Rows[0]);
            }
            return null;
        }
        public static bool InsertAccount(AccountDTO ac)// Kiểm tra thêm tài khoản
        {
            string query = "Exec USP_InsertAccount @pass , @name , @passport , @placeofbirth , @telephone , @address , @right , @status ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] {ac.PassWord , ac.Name , ac.PassPort , ac.PlaceOfBirth, ac.Telephone, ac.Address, ac.Right , ac.Status }) == 1)
            {
                return true;
            }
            return false;
        }

        public static bool UpdateAccount(AccountDTO ac)// kiểm tra sửa
        {
            string query = "Exec USP_UpdateAccount @user , @pass , @name , @place , @telephone , @address , @right , @status  , @passport";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { ac.ID, ac.PassWord, ac.Name, ac.PlaceOfBirth, ac.Telephone, ac.Address, ac.Right, ac.Status, ac.PassPort }) == 1)
            {
                return true;
            }
            else
                return false;
        }

        public static bool ResetAccount(int user)// kiểm tra resetpas
        {
            string query = "UPDATE dbo.ACCOUNT SET Pass = 1234567 where ID = @username ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { user }) == 1)
            {
                return true;
            }
            else
                return false;
        }

        public static bool DeleteAccount(AccountDTO ac)// kiểm tra xóa tài khoản
        {
            string query = "Exec USP_DeleteAccount @user";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { ac.ID }) == 1)
            {
                return true;
            }
            return false;
        }

        public static bool IsExistAccount(int user)// kiểm tra xem tài khoản đang tồn tại
        {
            string query = "Exec USP_Getusername @user ";//chưa thanh toán
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { user }) == 1)
            {
                return true;
            }
            return false;
        }

    }
}
