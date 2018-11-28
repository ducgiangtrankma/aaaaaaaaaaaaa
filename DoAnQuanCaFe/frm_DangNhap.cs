using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace DoAnQuanCaFe
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void XoaTruongDangNhap()
        {
            txtMatKhau.Text = "";
            lblNotification.Text = "";
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int username = (int)cbxNhanVien.SelectedValue;
            string password = txtMatKhau.Text;
            if(Login(username,password))
            {
                Program.sAccount = AccountBUS.GetAccount(username);
                if (Program.sAccount.Status == 1)
                {
                    Program.sAccount = AccountBUS.GetAccount(username);
                    if (Program.sAccount.Right == 0)
                    {
                        XoaTruongDangNhap();

                        frm_TrangChu n = new frm_TrangChu();
                        this.Hide();
                        n.ShowDialog();
                        this.Show();
                        
                        LoadAccount();
                    }
                    else if (Program.sAccount.Right == 1)
                    {
                        XoaTruongDangNhap();
                        frm_YeuCauGoiThucUong y = new frm_YeuCauGoiThucUong();
                        this.Hide();
                        y.ShowDialog();
                        this.Show();
                        LoadAccount();
                    }
                    else
                        this.Close();
                }
                else
                {
                    Program.sAccount = null;
                    lblNotification.Text = "Tài khoản của bạn đã bị khóa bởi người quản trị.";
                }
            }
            else
                lblNotification.Text = "Bạn nhập sai tài khoản hoặc mật khẩu. Vui lòng nhập lại!";
        }
        bool Login(int username, string password)
        {
            return AccountBUS.IsLogin(username, password);
        }

        private void chkHidePass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHidePass.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            LoadAccount();
            cbxNhanVien.ContextMenu = new ContextMenu();
        }

        void LoadAccount()
        {
            //load loại thức uống theo tên
           // cbxNhanVien.Items.Clear();
            List<AccountDTO> listtype = AccountBUS.GetAllListAccount();
            cbxNhanVien.DataSource = listtype;
            cbxNhanVien.DisplayMember = "Name";
            cbxNhanVien.ValueMember = "ID";
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chỉnhSửaThôngTinTàiKhoảngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thiếtLặpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8 || Convert.ToInt32(e.KeyChar) == 64 || (Convert.ToInt32(e.KeyChar) >= 35 && Convert.ToInt32(e.KeyChar) <= 38) || (Convert.ToInt32(e.KeyChar) >= 65 && Convert.ToInt32(e.KeyChar) <= 90) || (Convert.ToInt32(e.KeyChar) >= 97 && Convert.ToInt32(e.KeyChar) <= 122) || (Convert.ToInt32(e.KeyChar) >= 48 && Convert.ToInt32(e.KeyChar) <= 57))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThongTinTaiKhoan frm_ThongTin = new frm_ThongTinTaiKhoan(AccountBUS.GetAccount((int)cbxNhanVien.SelectedValue));
            frm_ThongTin.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("THÔNG TIN PHẦN MỀM QUẢN LÝ \nSinh viên thực hiện:\nTrần Đức Giang\nPhạm Quang Hùng\nĐỗ Thị Thu Lệ\nKhoa CNTT - Học viện Kĩ thuật mật mã");
        }
    }
}
