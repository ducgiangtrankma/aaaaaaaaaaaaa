using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanCaFe
{
    public partial class frm_TrangChu : Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (Program.sAccount.Right == 0)
            {
                frm_QuanLyHeThong n = new frm_QuanLyHeThong();
                this.Hide();
                n.ShowDialog();
                if (Program.sAccount.Right == 1)
                {
                    btnAdmin.Visible = false;
                    MessageBox.Show("Tài khoản của bạn thuộc loại tài khoản nhân viên, bạn vui lòng đăng nhập lại!");
                    this.Close();

                }
                if (Program.sAccount.Status == 0)
                {
                    btnAdmin.Visible = false;
                    btnOrder.Visible = false;
                    MessageBox.Show("Tài khoản của bạn đã bị khóa nên không thể sử dụng các chức năng của hệ thống!");
                    this.Close();
                }
                this.Show();
            }
            else MessageBox.Show("Tài khoản của bạn không có quyền sử dụng chức năng này!"); 

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frm_YeuCauGoiThucUong frm_Order = new frm_YeuCauGoiThucUong();
            this.Hide();
            frm_Order.ShowDialog();
            if (Program.sAccount.Right == 1)
            {
                btnAdmin.Visible = false;

            }
            if (Program.sAccount.Status == 0)
            {
                btnAdmin.Visible = false;
                btnOrder.Visible = false;
                MessageBox.Show("Tài khoản của bạn đã bị khóa vui lòng đăng xuất khỏi hệ thống!"); 
            }
            this.Show();
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frm_ThongTinTaiKhoan frm_ThongTin = new frm_ThongTinTaiKhoan(Program.sAccount);
            frm_ThongTin.ShowDialog();
        }

        private void fTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void fTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //this.Close();
            DialogResult kq = MessageBox.Show("Bạn có thực sự muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (kq == DialogResult.Cancel)
                ;
            else
            {
                Program.sAccount = null;
                this.Close();
                frm_DangNhap frm = new frm_DangNhap();
                frm.XoaTruongDangNhap();
            }
        }


    }
}
