using BUS;
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
    public partial class frm_ThanhToan : Form
    {
        private int _MaHD;
        private int _MaBan;
        private string _TongTien;
        private string _TenHD;
        public bool _KetQua = false;

        public frm_ThanhToan(string TenHD,int MaBan,int MaHD,string TongTien)
        {
            InitializeComponent();
            _TenHD = TenHD;
            txtMaHD.Text = "HD00" + MaHD.ToString();
            txtTongTien.Text = TongTien.ToString();

            _MaHD = MaHD;
            _MaBan = MaBan;
            _TongTien = TongTien.Replace(",", "").ToString();

            timer1.Enabled = true;
        }

        private void frm_ThanhToan_Load(object sender, EventArgs e)
        {
            txtSTK.ContextMenu = new ContextMenu();
        }

        private void txtSTK_TextChanged(object sender, EventArgs e)
        {

            if (txtSTK.Text != "")
            {
                //

                //
                if (txtSTK.Text.Length <= 8)
                {
                    int stk = Convert.ToInt32(txtSTK.Text);
                    int tongtien = Convert.ToInt32(_TongTien);
                    int kt = (stk - tongtien);
                    if (kt != 0)
                        txtTienTon.Text = String.Format("{0:0,0}", kt);
                    else txtTienTon.Text = "0";
                    
                    
                }
                else
                {
                    txtSTK.Text = "0";
                    txtTienTon.Text = "0";
                    MessageBox.Show("Vui lòng nhập số tiền nằm khoảng chừng số tiền khách hàng phải trả.");
                }

            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (txtSTK.Text != "")
            {
                _TongTien = _TongTien.Replace(",","").ToString();
                if (Convert.ToInt32(txtSTK.Text) < Convert.ToInt32(_TongTien))
                    MessageBox.Show("Hệ thống không cho phép khách hàng nợ, mong bạn thông cảm nhắc khách hàng thanh toán đúng số tiền trong hóa đơn.");
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn thanh toán hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq != DialogResult.No)
                    {
                        //
                        // Hiển thị report
                        rptThanhToan rptThanhToan = new rptThanhToan();
                        DateTime Time = DateTime.Now;
                        rptThanhToan.XuatHoaDon(_MaHD,_TenHD,"Bàn số "+ _MaBan,Program.sAccount.Name, Time,_TongTien, txtSTK.Text, txtTienTon.Text,true);
                        //
                        rptThanhToan.ShowDialog();
                        BillBUS.UpdatetBill(_MaHD, Convert.ToDouble(_TongTien.ToString()), Time, Program.sAccount.ID);
                        TableBUS.UpdateStatusTable(0, _MaBan); // Cập nhật da
                        
                        _KetQua = true;
                        this.Close();
                    }
                    else _KetQua = false;
                }
            }
            else MessageBox.Show("Nhập tiền khách cần thanh toán cho hóa đơn này!");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void txtHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyCode dành cho text nhập số
            if ((Convert.ToInt32(e.KeyChar) >= 48 && Convert.ToInt32(e.KeyChar) <= 57) || Convert.ToInt32(e.KeyChar) == 8)
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }
    }
}
