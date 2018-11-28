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
    public partial class frm_ThongTinChiTietSanPham : Form
    {
        
        private static int idBill;

        public static int IdBill
        {
            get { return frm_ThongTinChiTietSanPham.idBill; }
            set { frm_ThongTinChiTietSanPham.idBill = value; }
        }
        private static int idDrink;

        public static int IdDrink
        {
            get { return frm_ThongTinChiTietSanPham.idDrink; }
            set { frm_ThongTinChiTietSanPham.idDrink = value; }
        }

        private static int idTable;

        public static int IdTable
        {
            get { return frm_ThongTinChiTietSanPham.idTable; }
            set { frm_ThongTinChiTietSanPham.idTable = value; }
        }
        

        public frm_ThongTinChiTietSanPham(int idTable, int idBill,int idDrink,int k)
        {
            InitializeComponent();
            IdTable = idTable;
            IdBill = idBill;
            IdDrink = idDrink;
            int n = k - 1;
            if (n <= 50)
                n = 50;
            for (int i = 1; i <= n; i++)
            {
                cbQuantity.Items.Add(i);
            }
        }

        private void fDetailOneDrinkBill_Load(object sender, EventArgs e)
        {
            cbQuantity.ContextMenu = new ContextMenu();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            DialogResult kq = MessageBox.Show("Bạn có muốn xóa sản phẩm này không?","Thông báo",MessageBoxButtons.OKCancel);
            if (kq != DialogResult.Cancel)
            {
                DetailBillBUS.DeleteOneDrink(idBill, idDrink);
                // Xóa sản phẩm trong detail bill thông qua ma hóa đơn.
                // Nếu trong hóa đơn đó không còn sản phẩm thì xóa hóa đơn ===>> cập nhật lại trạng thái bàn.
                if (!BUS.DetailBillBUS.IsEmpty(idBill))
                {
                    BUS.BillBUS.DeleteBill(idBill);
                    TableBUS.UpdateStatusTable(0, idTable);
                }
                //Ngược lại không làm gì cả.....
            }  
        }

        private void btnAccept_Click_1(object sender, EventArgs e)
        {

        }

        private void cbQuantity_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
