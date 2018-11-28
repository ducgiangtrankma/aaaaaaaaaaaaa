using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS //Lớp nghiệp vụ - Business Logic Layer - Kiểm tra các yêu cầu nghiệp vụ khi cập nhật dữ liệu. -  Nhận lệnh từ giao diện và gọi các lệnh trong DAO để check
{
    public class AccountBUS
    {
        public static bool IsLogin(int id, string password) // Kiểm tra tài khoản đăng nhập vào
        {
            return AccountDAO.IsLogin(id,password);
        }
        public static List<AccountDTO> GetAllListAccount()// Lấy ra danh sách các Acc
        {
            return AccountDAO.GetAllListAccount();
        }

        public static List<AccountDTO> GetListAccountOnStatus(int status)
        {
            return AccountDAO.GetListAccountOnStatus(status);
        }
        public static bool InsertAccount(AccountDTO ac)// Thêm Tài Khoản
        {
            return AccountDAO.InsertAccount(ac);
        }
        public static bool UpdateAccount(AccountDTO ac)// sửa tài khoản
        {
            return AccountDAO.UpdateAccount(ac);
        }
        public static bool DeleteAccount(AccountDTO ac)// xòa tài khoản
        {
            return AccountDAO.DeleteAccount(ac);
        }
        public static bool IsExistAccount(int id)//
        {
            return AccountDAO.IsExistAccount(id);
        }
        public static bool ResetAccount(int user) // Reset lại mật khẩu
        {
            return AccountDAO.ResetAccount(user);
        }
        public static int GetRightByAccount(int user)// ?
        {
            return AccountDAO.GetRightByAccount(user);
        }
        public static string GetNameByAccount(int user)
        {
            return AccountDAO.GetNameByAccount(user);
        }

        public static AccountDTO GetAccount(int user)
        {
            return AccountDAO.GetAccount(user);
        }
    }
}
