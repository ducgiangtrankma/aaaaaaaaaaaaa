using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Globalization;
using System.Threading; 

namespace DoAnQuanCaFe
{
    public partial class frm_YeuCauGoiThucUong : Form
    {
        private object objTable; // Đối tượng bàn
        public frm_YeuCauGoiThucUong()
        {
            InitializeComponent();
            LoadTable();
            LoadTypeDrink();
            tssNhanVien.Text = "Nhân viên đang đăng nhập: " + Program.sAccount.Name;
        }

        public void fOrder_Load(object sender, EventArgs e)
        {
            LoadDrinkListByTypeDrinkID(DrinkBUS.GetListDrinkByIDTypeDrink(0, 1));
            
            cbLoaiThucUong.ContextMenu = new ContextMenu();
            timer1.Enabled = true;
            btnThanhToan.Enabled = false;
            btnTamTinh.Enabled = false;
        }

        void LoadTypeDrink()
        {
            //load loại thức uống theo tên
            List<TypeDrinkDTO> listtype = TypeDrinkBUS.GetListTypeDrinkWithStatusOne(1);
            cbLoaiThucUong.DataSource = listtype;
            cbLoaiThucUong.DisplayMember = "NameType";
        }
        
        void LoadDrinkListByTypeDrinkID(List<DrinkDTO> listdrink) // Lấy dữ liệu sản phẩm từ csdl
        {
            lstSanPham.Items.Clear();
            for (int i = 0; i < listdrink.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "#" + (i + 1).ToString();
                item.SubItems.Add(listdrink[i].NameDrinks);
                if (listdrink[i].SalePrice==0)
                    item.SubItems.Add("Miễn phí");
                else
                    item.SubItems.Add(listdrink[i].SalePrice.ToString("0,0 VNĐ"));
                item.Tag = listdrink[i];
                lstSanPham.Items.Add(item);
            }
        }

        public void LoadTable()
        {
            flbTable.Controls.Clear();// reset lai flb để load full
            //load bàn lên trên panel
            List<TableDTO> tablelist = TableBUS.GetAllListTable();

            foreach (TableDTO item in tablelist)
            {
                Button button = new Button();
                
                    button.Width = TableBUS.TabWidth;
                    button.Height = TableBUS.TabHeight;
               
                button.Text = item.NameTable + Environment.NewLine + "Có";
                button.Name = "B"+item.ID;
                button.Click += button_Click;
                button.Tag = null;
                button.Tag = item;
                if (BUS.TableBUS.GetStatusByIDTable(item.ID) == 0)
                {
                    button.BackColor = Color.Aqua;
                    button.Text = item.NameTable + Environment.NewLine + "Trống";
                }
                else
                    button.BackColor = Color.LightPink;

                flbTable.Controls.Add(button);
            }
        }
        public void ShowBill(int id)
        {
            //load bill lên theo theo mã bàn
            lstBill.Items.Clear();

            List<MenuDTO> menulist = MenuBUS.GetListMenuByIDTable(id);
            double totalPrice = 0;
            for (int i = 0; i < menulist.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = menulist[i].NameDrink.ToString();
                listitem.SubItems.Add(menulist[i].Quantity.ToString());
                if (menulist[i].PriceBasic == 0)
                    listitem.SubItems.Add("Miễn phí");
                else
                    listitem.SubItems.Add(String.Format("{0:0,0}", menulist[i].PriceBasic) + " VNĐ");
                if (menulist[i].TotalPrice == 0)
                    listitem.SubItems.Add("Miễn phí");
                else 
                    listitem.SubItems.Add(String.Format("{0:0,0}", menulist[i].TotalPrice) + " VNĐ");
                totalPrice += menulist[i].TotalPrice;
                listitem.Tag = menulist[i];
                listitem.SubItems.Add("#"+(i + 1).ToString());
                lstBill.Items.Add(listitem);
            }
            if (totalPrice > 0)
            txttotalPrice.Text = String.Format("{0:0,0}", totalPrice);
        }

        private void hoverClickButton(object sender)
        {
            Button btnTableLast = (Button)sender;
            if (objTable != null)
            {
                Button btnTablePresent = (Button)objTable;
                int sttTable = TableBUS.GetStatusByIDTable((btnTablePresent.Tag as TableDTO).ID);
                if (sttTable == 1)
                {
                    btnTablePresent.BackColor = Color.LightPink;
                }
                else btnTablePresent.BackColor = Color.Aqua;
                btnTablePresent.ForeColor = Color.Black;
            }
            btnTableLast.BackColor = Color.LightBlue;
            btnTableLast.ForeColor = Color.White; // Mau chu
            objTable = sender;
        }
        object choseTable;
        public void button_Click(object sender, EventArgs e)
        {
            hoverClickButton(sender);
            choseTable = sender;
            txtHD.Text = "";
            txtBan.Text = "";
            
            // Viết hàm lấy thông tin bàn bằng mã
            Button btnTable = (Button)sender;
            lstBill.Tag = btnTable.Tag;
            // Kiểm tra trạng thai ở
            int idTable = (btnTable.Tag as TableDTO).ID;
            txtBan.Text = (btnTable.Tag as TableDTO).NameTable + "";
            btnThanhToan.Enabled = false;
            btnTamTinh.Enabled = false;
            cbLoaiThucUong.Enabled = true;
            lstSanPham.Enabled = true;
            txttotalPrice.Text = "0";
            if (TableBUS.GetStatusByIDTable(idTable) == 1)
            {
                txtHD.Text = "HD00" + (string)BillBUS.GetIDBillNoPaymentByIDTable((int)idTable).ToString();
                btnThanhToan.Enabled = true;
                btnTamTinh.Enabled = true;
                if (lstBill.Tag != null)
                {
                    ShowBill(idTable);
                }
            }
            else
            {
                lstBill.Items.Clear();
            }
        }

        private void cbLoaiThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLoaiThucUong.SelectedIndex >= 0)
            {
                //khi load loại loại thức uống thì sẽ gán loại theo cái thức uống.
                int id = 0;
                if (cbLoaiThucUong.SelectedItem == null)
                    return;
                TypeDrinkDTO typedrink = cbLoaiThucUong.SelectedItem as TypeDrinkDTO;
                id = typedrink.ID;
                LoadDrinkListByTypeDrinkID(DrinkBUS.GetListDrinkByIDTypeDrink(id, 1));
            }
        }
      
        private TableDTO CreateAddBillByIDTable(DrinkDTO drink)
        {
            TableDTO table = lstBill.Tag as TableDTO;


            int idBill = BillBUS.GetIDBillNoPaymentByIDTable(table.ID);//lấy lên cái mã id của hóa đơn 

            // int idDrink = (cbDrink. SelectedItem as DrinkDTO).ID;//thêm vào 1 gridview để hiển thị
            int idDrink = drink.ID;
            int quantity = 1;
            //kiểm tra hóa đơn có chưa hay
            if (idBill == -1)//nếu chưa thì tạo 1 hóa đơn mới với mã hóa đơn
            {
                quantity = DetailBillBUS.GetQuantityDrink(idBill, idDrink);
                // sau khi tạo xong 1 hóa đơn mới thì thêm vào bảng chi tiết hóa đơn với các trường tương ứng
                DetailBillBUS.InsertDetailBill(BillBUS.GetIDBillMax(), idDrink, quantity + 1);
            }
            else//nếu đã có thì thêm nó vào cái cá bảng chi tiêt hóa đơn với các trường là mã hóa đơn, mã thức uống và số lượng
            {
                quantity = DetailBillBUS.GetQuantityDrink(idBill, idDrink);
                DetailBillBUS.InsertDetailBill(idBill, idDrink, quantity + 1);
            }
            return table;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lstBill.Tag as TableDTO;
                int idBill = BillBUS.GetIDBillNoPaymentByIDTable(table.ID);
                frm_ThanhToan frm_ThanhToan = new frm_ThanhToan("HÓA ĐƠN THANH TOÁN", table.ID, idBill, txttotalPrice.Text);
                //this.Hide();
                frm_ThanhToan.ShowDialog();
                if (frm_ThanhToan._KetQua)
                {
                    ShowBill(table.ID);

                    LoadTable();
                    LoadTypeDrink();
                    btnThanhToan.Enabled = false;
                    btnTamTinh.Enabled = false;
                    cbLoaiThucUong.Enabled = false;
                    lstSanPham.Enabled = false;
                    txttotalPrice.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì, vui lòng thử lại sau.");
            }
        }

        private void lstBill_MouseClick(object sender, MouseEventArgs e)
        {
            TableDTO table = ((Button)objTable).Tag as TableDTO;
         
            int idBill = BillBUS.GetIDBillNoPaymentByIDTable(table.ID);
            
            if (lstBill.SelectedItems.Count > 0)
            {
                MenuDTO order = (MenuDTO)lstBill.SelectedItems[0].Tag as MenuDTO;

                frm_ThongTinChiTietSanPham de = new frm_ThongTinChiTietSanPham(table.ID,idBill, order.IdDrink, Convert.ToInt32(order.Quantity) + 1);
                de.lblDrinkName.Text = order.NameDrink;
                if (order.PriceBasic == 0)
                    de.lblPrice.Text = "Miễn phí";
                else
                    de.lblPrice.Text = String.Format("{0:0,0}", order.PriceBasic);
                de.cbQuantity.SelectedIndex = Convert.ToInt32(order.Quantity) - 1;
                if (order.TotalPrice == 0)
                    de.lblTotal.Text = "Miễn phí";
                else
                    de.lblTotal.Text = String.Format("{0:0,0}", order.TotalPrice);
                DialogResult kq = de.ShowDialog();
                if (kq == DialogResult.OK)
                {
                    DetailBillBUS.InsertDetailBill(idBill, order.ID, de.cbQuantity.SelectedIndex + 1);
                    ShowBill(table.ID);
                }
                else if (kq == DialogResult.Yes)
                {
                    ShowBill(table.ID);
                    Button btnTable = ((Button)objTable);
                    btnTable.Text = table.NameTable + Environment.NewLine + "Trống";
                    if (!BUS.DetailBillBUS.IsEmpty(idBill))
                    {
                        btnTamTinh.Enabled = false;
                        btnThanhToan.Enabled = false;
                        txttotalPrice.Text = "";
                        txtHD.Text = "";
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHD.Text = "";
            lstBill.Items.Clear();
            txtBan.Text = "";
            txttotalPrice.Text = "0";
            objTable = null;
            choseTable = null;
            btnThanhToan.Enabled = false;
            btnTamTinh.Enabled = false;
            LoadTypeDrink();
            txtTuKhoa.Text = "";
            LoadTable();
            
        }

        private void btnTachBan_Click(object sender, EventArgs e)
        {
            frm_ThaoTacBan t = new frm_ThaoTacBan();
            this.Hide();
            t.ShowDialog();
            this.LoadTable();
            lstBill.Items.Clear();
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNgayHienTai.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDrinkListByTypeDrinkID(DrinkBUS.GeDrinkByName(txtTuKhoa.Text));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TableDTO table = lstBill.Tag as TableDTO;
                int idBill = BillBUS.GetIDBillNoPaymentByIDTable(table.ID);

                rptThanhToan frm_TToan = new rptThanhToan();
                DateTime Time = DateTime.Now;
                frm_TToan.XuatHoaDon(idBill, "HÓA ĐƠN TẠM TÍNH", "Bàn số " + table.ID, Program.sAccount.Name, Time, string.Format("{0:0,0}", txttotalPrice.Text), "0", "0",true);
                //
                frm_TToan.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì, thử lại.");
            }
        }

        private void cbLoaiThucUong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSanPham.SelectedItems.Count > 0)
            {
                DrinkDTO drink = lstSanPham.SelectedItems[0].Tag as DrinkDTO;
                // Them qua ListView
                //kiểm tra đã chọn bàn hay chưa
                try
                {
                    if (choseTable != null)
                    {
                        if ((objTable as Button).Tag != null)
                        {
                            Button btnTable = (objTable as Button);
                            //tag cái bàn đang chọn vào
                            TableDTO table = (objTable as Button).Tag as TableDTO;
                            int idTable = table.ID;
                            if (TableBUS.GetStatusByIDTable(idTable) == 0)
                            {
                                DialogResult kq = MessageBox.Show("Bạn đang chọn bàn mới.\n Bạn có muốn tạo hóa đơn mới cho bàn này chứ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (kq == DialogResult.OK)
                                {
                                    btnThanhToan.Enabled = true;
                                    btnTamTinh.Enabled = true;
                                    lstBill.Tag = (choseTable as Button).Tag;
                                    //ShowBill(idTable);
                                    // Cap nhat trang thai bàn
                                    TableBUS.UpdateStatusTable(1, idTable);
                                    // Tao hóa đơn mới ở đây.
                                    BillBUS.InsertBill(DateTime.Now, 0, Program.sAccount.ID, idTable);
                                    txtHD.Text = "HD00" + (string)BillBUS.GetIDBillNoPaymentByIDTable((int)idTable).ToString();
                                    btnTable.Text = table.NameTable + Environment.NewLine + "Có";
                                }
                                else
                                {
                                    lstBill.Items.Clear();
                                    btnThanhToan.Enabled = false;
                                    btnTamTinh.Enabled = false;
                                    cbLoaiThucUong.Enabled = false;
                                    txtHD.Text = "";
                                }
                            }
                            table = CreateAddBillByIDTable(drink);
                            ShowBill(table.ID);
                        }
                    }
                    else MessageBox.Show("Bạn chưa chọn bàn để thêm thức uống. Vui lòng chọn bàn để tiếp tục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch
                {
                    MessageBox.Show("Hệ thống đang bảo trì, bạn quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void lstBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
