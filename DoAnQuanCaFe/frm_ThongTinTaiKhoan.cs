using BUS;
using DTO;
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
    public partial class frm_ThongTinTaiKhoan : Form
    {
        private AccountDTO _Account;
        public frm_ThongTinTaiKhoan(AccountDTO acc)
        {
            InitializeComponent();
            _Account = acc;
            //Program.sAccount = AccountBUS.GetAccount(Program.sAccount.UserName);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LayLaiMatKhau frm = new frm_LayLaiMatKhau(Program.sAccount, 0);
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            lblName.Text = _Account.Name;
            lblNoiSinh.Text = _Account.PlaceOfBirth;
            lblSDT.Text = _Account.Telephone;
            lblDiaChi.Text = _Account.Address;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            frm_LayLaiMatKhau frm = new frm_LayLaiMatKhau(_Account, 1);
            frm.ShowDialog();
        }
    }
}
