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

namespace DoAnQuanCaFe
{
    public partial class frm_QuanLyHeThong : Form
    {
        public frm_QuanLyHeThong()
        {
            InitializeComponent();
            tssNhanvien.Text = "Nhân viên đang đăng nhập: " + Program.sAccount.Name;
            tssThoiGian.Text = " - Ngày hiện tại: " + DateTime.Now.ToString("dd/MM/yyyy");

            ShowDrink();
            ShowTable();
            LoadTypeDrink(cbLocLoaiSP); // Loại
            LoadTypeDrink(cbTypeDrink); // Loại
            ShowAccout();
            ShowTypeDrink();            
            ShowTable();
            LoadDateTimePicker();

            btnEditTypeDrink.Visible = false;
            btnEditDrink.Visible = false;
            btnDeleteAccount.Enabled = false;
            this.btnAddAccount.Visible = true;
            this.btnEditAccount.Visible = false ;
        }
        public void ShowDrink()
        {
            lstDrink.Items.Clear();
            List<DrinkDTO> menulist = DrinkBUS.GetAllListDrink();
            CreateListDrink(menulist);
        }
        void LoadDateTimePicker()// Load time
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }

        private void CreateListDrink(List<DrinkDTO> menulist)
        {
            for (int i = 0; i < menulist.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = "#" + (i + 1).ToString();
                listitem.SubItems.Add(menulist[i].NameDrinks);
                if (menulist[i].PriceBasic == 0)
                {
                    listitem.SubItems.Add("Miễn phí");
                }
                else listitem.SubItems.Add(menulist[i].PriceBasic.ToString("0,000"));

                if (menulist[i].SalePrice == menulist[i].PriceBasic)
                    listitem.SubItems.Add("Không có chương trình khuyến mãi");
                else
                {
                    int phantram = (int)((menulist[i].SalePrice * 100) / menulist[i].PriceBasic);
                    listitem.SubItems.Add("Đang giảm " + phantram + "%");
                }
                if (menulist[i].Status == 1)
                {
                    listitem.SubItems.Add("Đang họat động");
                }
                else
                {
                    listitem.SubItems.Add("Ngưng bán");
                }
                listitem.SubItems.Add("SP00" + menulist[i].ID);
                listitem.Tag = menulist[i];
                lstDrink.Items.Add(listitem);
            }
        }


        private void btnAdddrink_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDrinkName.Text == "" || txtPriceDrink.Text == "")
                {
                    MessageBox.Show("Bạn không thể thêm nếu như để trống một trường dữ liệu nào.", "Thông báo", MessageBoxButtons.OK);
                }
                else 
                {
                    DrinkDTO sp = new DrinkDTO();

                    sp.NameDrinks = txtDrinkName.Text;
                    sp.PriceBasic = Convert.ToDouble(txtPriceDrink.Text);
                    sp.SalePrice = sp.PriceBasic;
                    if (radAn.Checked)
                    {
                        sp.Status = 0;
                    }
                    else
                        sp.Status = 1;
                    sp.SalePrice = sp.PriceBasic;
                    // Chọn loại sản phẩm
                    TypeDrinkDTO typedrink = cbTypeDrink.SelectedItem as TypeDrinkDTO;
                    sp.IDTypeDrink = typedrink.ID;

                    if (DrinkBUS.InsertDrink(sp) == true)
                    {
                        MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK);
                        ShowDrink();
                        DeleteTextDrink();
                    }
                    else
                        MessageBox.Show("Thêm mới sản phẩm thất bại, vui lòng kiểm tra dữ liệu nhập vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        void LoadTypeDrink(ComboBox cmb)
        {
            List<TypeDrinkDTO> listtype = TypeDrinkBUS.GetListTypeDrinkWithStatusOne(1);
            cmb.DataSource = listtype;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "NameType";
        }

        private void btnEditDrink_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDrink.SelectedItems.Count > 0)
                {
                    if (txtDrinkName.Text == "" || txtPriceDrink.Text == "")
                    {
                        MessageBox.Show("Bạn không thể cập nhật nếu như để trống một trường dữ liệu nào.", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DrinkDTO sp = lstDrink.SelectedItems[0].Tag as DrinkDTO;
                        sp.NameDrinks = txtDrinkName.Text;
                        sp.PriceBasic = Convert.ToDouble(txtPriceDrink.Text);
                        // Dành cho phát triển thêm chức năng quản lý khuyến mãi
                        sp.SalePrice = sp.PriceBasic;

                        if (radAn.Checked)
                        {
                            sp.Status = 0;
                        }
                        else
                            sp.Status = 1;

                        TypeDrinkDTO typedrink = cbTypeDrink.SelectedItem as TypeDrinkDTO;
                        sp.IDTypeDrink = typedrink.ID;

                        if (DrinkBUS.UpdateDrink(sp))
                        {
                            ShowDrink();
                            MessageBox.Show("Bạn đã cập nhật sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK);
                            DeleteTextDrink();
                            btnAdddrink.Visible = true;
                            btnEditDrink.Visible = false;
                            btnDeDrink.Enabled = false;
                        }
                        else
                            MessageBox.Show("Hiện tại bạn đã cập nhật thông tin sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng chọn sản phẩm trước khi thực hiện chức năng này!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void lstDrink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDrink.SelectedItems.Count > 0)
            {
                btnDeDrink.Enabled = true;
                btnAdddrink.Visible = false;
                btnEditDrink.Visible = true;
                ListViewItem lvw = lstDrink.SelectedItems[0];
                DrinkDTO sp = (DrinkDTO)lvw.Tag;
                txtIDDrink.Text = "SP00"+sp.ID.ToString();
                txtDrinkName.Text = sp.NameDrinks;
                txtPriceDrink.Text = sp.PriceBasic.ToString();
                cbTypeDrink.SelectedValue = sp.IDTypeDrink;
                if (sp.Status == 1)
                {
                    radHien.Checked = true;
            
                }
                else 
                    radAn.Checked = true;
            }
        }

        private void btnWatchDrink_Click(object sender, EventArgs e)
        {
            DeleteTextDrink();
        }

        void DeleteTextDrink()
        {
            btnDeDrink.Enabled = false;
            btnAdddrink.Visible = true;
            btnEditDrink.Visible = false;
            txtDrinkName.Text = "";
            txtPriceDrink.Text = "";
            txtIDDrink.Text = "";
            radHien.Checked = true;
            ShowDrink();
            LoadListTypeDrink(cbLocLoaiSP);
            LoadListTypeDrink(cbTypeDrink);
        }

        private void btnDeDrink_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDrink.SelectedItems != null)
                {
                    ListViewItem lvw = lstDrink.SelectedItems[0];
                    DrinkDTO sp = (DrinkDTO)lvw.Tag;
                    frm_XacNhan frm_XN = new frm_XacNhan("Xóa một sản phẩm rất quan trọng. Bạn vui lòng nhập mật khẩu để xác nhận thao tác này!", Program.sAccount);
                    if (frm_XN.ShowDialog() == DialogResult.OK)
                    {
                        if (AccountBUS.IsLogin(Program.sAccount.ID, frm_XN.txtXacNhap.Text))
                        {
                            if (DetailBillBUS.IsExistDrink(sp.ID) == -1)
                            {
                                if (lstDrink.SelectedItems.Count > 0)
                                {
                                    if (DrinkBUS.DeleteDrink(sp) == true)
                                    {
                                        MessageBox.Show("Bạn đã xóa thành công sản phẩm SP00"+ sp.ID +" khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK);
                                        ShowDrink();
                                        DeleteTextDrink();
                                        btnEditDrink.Visible = false;
                                        btnAdddrink.Visible = true;
                                    }
                                    else
                                        MessageBox.Show("Xóa sản phẩm thất bại, vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    MessageBox.Show("Chưa chọn thức uống", "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                            else
                                MessageBox.Show("Thức uống này đã được người dùng chọn hoặc mua trong thời gian trước đó, bạn không thể xóa sản phẩm này!", "Thông báo", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("Bạn nhập sai mật khẩu, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else MessageBox.Show("Bạn vui lòng chọn sản phẩm trước khi thực hiện chức năng này!", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        void ShowTypeDrink()
        {
            lstTypeDrink.Items.Clear();
            List<TypeDrinkDTO> menulist = TypeDrinkBUS.GetAllListTypeDrink();
            for (int i = 0; i < menulist.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = "#"+ (i + 1).ToString();
                listitem.SubItems.Add(menulist[i].Nametype.ToString());
                if (menulist[i].Status == 1)
                {
                    listitem.SubItems.Add("Đang họat động");
                } 
                else
                    listitem.SubItems.Add("Khóa");
                listitem.SubItems.Add("LSP00"+menulist[i].ID.ToString());
                listitem.Tag = menulist[i];
                lstTypeDrink.Items.Add(listitem);
            }
            
        }

        private void btnAddTypeDrink_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTypeDrinkName.Text == "")
                {
                    MessageBox.Show("Bạn không thể cập nhật nếu như để trống một trường dữ liệu nào.", "Thông báo", MessageBoxButtons.OK);
                }
                else 
                {
                    TypeDrinkDTO sp = new TypeDrinkDTO();
                    sp.Nametype = txtTypeDrinkName.Text;

                    if (this.radAnType.Checked)
                    {
                        sp.Status = 0;
                    }
                    else
                        sp.Status = 1;

                    if (TypeDrinkBUS.InsertTypeDrink(sp) == true)
                    {
                        MessageBox.Show("Đã thêm mới loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
                        ShowTypeDrink();
                        LoadTypeDrink(cbTypeDrink);
                        LoadTypeDrink(cbLocLoaiSP);
                        DeleteTextType();
                    }
                    else
                        MessageBox.Show("Bạn đã thêm loại sản phẩm thất bại, vui lòng kiểm tra thông tin nhập vào!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void lstTypeDrink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTypeDrink.SelectedItems.Count > 0)
            {
                btnEditTypeDrink.Visible = true;
                btnAddTypeDrink.Visible = false;
                btnDeTypeDrink.Enabled = true;
                ListViewItem lvw = lstTypeDrink.SelectedItems[0];
                TypeDrinkDTO sp = (TypeDrinkDTO)lvw.Tag;
                txtIDTypeDrink.Text = "LSP00"+sp.ID.ToString();
                txtTypeDrinkName.Text = sp.Nametype;
                if (sp.Status == 1)
                {
                    this.radHienType.Checked = true;
                }
                else
                    radAnType.Checked = true;
            }
        }

        private void btnEditTypeDrink_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTypeDrink.SelectedItems.Count > 0)
                {
                    if (this.txtTypeDrinkName.Text == "")
                    {
                        MessageBox.Show("Bạn không thể cập nhật nếu như để trống một trường dữ liệu nào.", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        TypeDrinkDTO sp = lstTypeDrink.SelectedItems[0].Tag as TypeDrinkDTO;
                        sp.Nametype = txtTypeDrinkName.Text;
                        if (this.radAnType.Checked)
                        {
                            sp.Status = 0;
                        }
                        else
                            sp.Status = 1;

                        if (TypeDrinkBUS.UpdateTypeDrink(sp))
                        {
                            ShowTypeDrink();
                            MessageBox.Show("Đã cập nhật loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
                            DeleteTextType();
                            LoadTypeDrink(cbLocLoaiSP);
                            LoadTypeDrink(cbTypeDrink);
                        }
                        else
                            MessageBox.Show("Bạn đã cập nhật loại sản phẩm thất bại, vui lòng kiểm tra thông tin nhập vào!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng chọn sản phẩm trước khi thực hiện chức năng này!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDeTypeDrink_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTypeDrink.SelectedItems.Count > 0)
                {
                    TypeDrinkDTO sp = lstTypeDrink.SelectedItems[0].Tag as TypeDrinkDTO;
                    frm_XacNhan frm_XN = new frm_XacNhan("Vui lòng nhập mật khẩu để xác nhận thao tác này!", Program.sAccount);
                    if (frm_XN.ShowDialog() == DialogResult.OK)
                    {
                        if (AccountBUS.IsLogin(Program.sAccount.ID, frm_XN.txtXacNhap.Text))
                        {
                            if ((DrinkBUS.GetIDTypeDrinkByIDDrink(sp.ID)) == -1)
                            {
                                if (TypeDrinkBUS.DeleteTypeDrink(sp))
                                {
                                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK);
                                    ShowTypeDrink();
                                    DeleteTextType();
                                    LoadTypeDrink(cbLocLoaiSP);
                                    LoadTypeDrink(cbTypeDrink);
                                }
                                else
                                    MessageBox.Show("Thực hiện xóa thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK);
                            }
                            else { MessageBox.Show("Bạn vui lòng xóa tất cả sản phẩm đang thuộc loại sản phẩm này, trước khi thực hiện chức năng này", "Thông báo", MessageBoxButtons.OK); }
                        }
                        else MessageBox.Show("Bạn nhập sai mật khẩu, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                    MessageBox.Show("Bạn chưa chọn loại sản phẩm nào!", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnNewType_Click(object sender, EventArgs e)
        {
            DeleteTextType();
        }
        void DeleteTextType()
        {
            btnDeTypeDrink.Enabled = false;
            btnAddTypeDrink.Visible = true;
            btnEditTypeDrink.Visible = false;
            txtTypeDrinkName.Text = "";
            txtIDTypeDrink.Text = "";
            radHienType.Checked = true;
            ShowTypeDrink();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatType_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteTable.Enabled = true;
            if (lstTable.SelectedItems.Count > 0)
            {
                ListViewItem lvw = lstTable.SelectedItems[0];
                TableDTO sp = (TableDTO)lvw.Tag;
                txtTableName.Text = sp.NameTable;
                txtIDTable.Text = "B00"+sp.ID;
            }
        }

        void ShowTable()
        {
            this.lstTable.Items.Clear();
            List<TableDTO> menulist = TableBUS.GetAllListTable();
            for (int i = 0; i < menulist.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = "#" + (i + 1).ToString();
                listitem.SubItems.Add(menulist[i].NameTable.ToString());
                listitem.SubItems.Add("B00"+menulist[i].ID.ToString());
                if (menulist[i].Status == 0)
                    listitem.SubItems.Add("Bàn trống");
                else listitem.SubItems.Add("Bàn đang có khách");
                listitem.Tag = menulist[i];
                lstTable.Items.Add(listitem);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTableName.Text == "")
                {
                    MessageBox.Show("Bạn không thể thêm nếu như để trống một trường dữ liệu nào.", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    TableDTO sp = new TableDTO();
                    sp.NameTable = txtTableName.Text;
                    sp.Status = 0;
                    if (TableBUS.InsertTable(sp))
                    {
                        ShowTable();
                        DeleteTextTable();
                        MessageBox.Show("Bạn đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Bạn thêm mới thất bại, thử lại.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstTable.SelectedItems.Count > 0)
                {
                    TableDTO sp = lstTable.SelectedItems[0].Tag as TableDTO;
                    frm_XacNhan frm_XN = new frm_XacNhan("Vui lòng nhập mật khẩu để xác nhận thao tác này!", Program.sAccount);
                    if (frm_XN.ShowDialog() == DialogResult.OK)
                    {
                        if (AccountBUS.IsLogin(Program.sAccount.ID, frm_XN.txtXacNhap.Text))
                        {
                            if (sp.Status == 0)
                            {
                                if (TableBUS.DeleteTable(sp) == true)
                                {
                                    btnDeleteTable.Enabled = false;
                                    MessageBox.Show("Bàn bạn chọn đã được xóa khỏi hệ thống", "Thông báo", MessageBoxButtons.OK);
                                    ShowTable();
                                }
                                else
                                    MessageBox.Show("Xóa bàn thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK);
                            }
                            else MessageBox.Show("Bàn " + sp.ID + " hiện chưa được thanh toán không thể xóa khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("Bạn nhập sai mật khẩu vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn bàn để thực hiện!", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì chức năng này, vui lòng quay lại sau nhé!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            DeleteTextTable();
        }

        void DeleteTextTable()
        {
            txtTableName.Text = "";
            txtIDTable.Text = "";
            btnDeleteTable.Enabled = false;
        }

        private void btnOutTable_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ShowAccout()
        {
            this.lstAccount.Items.Clear();
            List<AccountDTO> menulist = AccountBUS.GetAllListAccount();
            for (int i = 0; i < menulist.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = "#" + (i + 1).ToString();
                listitem.SubItems.Add("03060"+menulist[i].ID.ToString());
                listitem.SubItems.Add(menulist[i].Name);
                listitem.SubItems.Add(menulist[i].PlaceOfBirth);
                listitem.SubItems.Add(menulist[i].Telephone);
                listitem.SubItems.Add(menulist[i].Address);
                if(menulist[i].Right == 0)
                {
                    listitem.SubItems.Add("Quản lý");
                }
                else
                    listitem.SubItems.Add("Nhân viên");
                if (menulist[i].Status == 0)
                {
                    listitem.SubItems.Add("Bị khóa");
                }
                else
                    listitem.SubItems.Add("Đã được mở khóa");
                listitem.SubItems.Add(menulist[i].PassPort);
                listitem.Tag = menulist[i];
                lstAccount.Items.Add(listitem);
            }
        }
        //
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtHoTen.Text == "" || this.txtTelephone.Text == "" ||
                    txtAddress.Text == "" ||
                    txtCMND.Text == "")
                {
                    MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin nhé!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    if (txtCMND.Text.Length >= 9 && txtCMND.Text.Length <= 15)
                    {
                        if (txtTelephone.Text.Length == 10 || txtTelephone.Text.Length == 11)
                        {
                            AccountDTO sp = new AccountDTO();
                            sp.PassWord = txtPassword.Text;//
                            sp.Name = txtHoTen.Text;//
                            sp.PassPort = txtCMND.Text;
                            sp.PlaceOfBirth = txtNoiSinh.Text;
                            sp.Telephone = txtTelephone.Text;//
                            sp.Address = txtAddress.Text;//
                            if (radAd.Checked)//
                            {
                                sp.Right = 0;
                            }
                            else
                                sp.Right = 1;
                            if (radHienAccount.Checked) // 0 không hoạt động 1: hoạt động//
                            {
                                sp.Status = 1;
                            }
                            else
                                sp.Status = 0;
                            if (AccountBUS.InsertAccount(sp))
                            {
                                DeleteTextAccount();
                                ShowAccout();
                                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK);
                                txtNameAcount.ReadOnly = false;
                            }
                            else
                                MessageBox.Show("Thêm tài khoản thất bại", "Thông báo", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("Số điện thoại phải có 10 hoặc 11 số"); // Tiếp tục làm nhé;
                    }
                    else MessageBox.Show("Số chứng minh nhân dân nằm trong khoảng 9 - 15 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống hiện đang bảo trì bạn vui lòng quay lại sau nhé.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtHoTen.Text == "" || this.txtTelephone.Text == "" ||
                    txtAddress.Text == "" ||
                    txtCMND.Text == "")
                {
                    MessageBox.Show("Bạn vui lòng điền đầy đủ nhé!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    if (txtCMND.Text.Length >= 9 && txtCMND.Text.Length <= 15)
                    {
                        if (txtTelephone.Text.Length >= 10 && txtTelephone.Text.Length <= 11)
                        {
                            if (this.lstAccount.SelectedItems.Count > 0)
                            {
                                AccountDTO sp = lstAccount.SelectedItems[0].Tag as AccountDTO;
                                sp.PassWord = this.txtPassword.Text;
                                sp.Name = this.txtHoTen.Text;
                                sp.PlaceOfBirth = this.txtNoiSinh.Text;
                                sp.Telephone = this.txtTelephone.Text;
                                sp.Address = this.txtAddress.Text;
                                sp.PassPort = txtCMND.Text;
                                if (this.radAd.Checked)
                                {
                                    sp.Right = 0;
                                }
                                else
                                    sp.Right = 1;

                                if (radHienAccount.Checked)
                                {
                                    sp.Status = 1;
                                }
                                else
                                    sp.Status = 0;
                                if (sp.ID == Program.sAccount.ID && sp.Status == 0)
                                {
                                    MessageBox.Show("Bạn không thể khóa chính bạn.", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    if (AccountBUS.UpdateAccount(sp))
                                    {
                                        ShowAccout();
                                        MessageBox.Show("Bạn đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                        DeleteTextAccount();
                                        txtNameAcount.ReadOnly = false;
                                        this.btnEditAccount.Visible = false;
                                        this.btnAddAccount.Visible = true;
                                        btnDeleteAccount.Enabled = false;
                                        if (sp.ID == Program.sAccount.ID && sp.Right == 1)
                                        {
                                            Program.sAccount = sp;
                                            this.Close();
                                        }
                                    }
                                    else
                                        MessageBox.Show("Chưa cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chưa chọn tài khoản", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                        else MessageBox.Show("Số điện thoại phải có 10 hoặc 11 số"); // Tiếp tục làm nhé;
                    }
                    else MessageBox.Show("Số chứng minh nhân dân nằm trong khoảng 9 - 15 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống hiện đang bảo trì bạn vui lòng quay lại sau nhé.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void lstAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNameAcount.ReadOnly = true; 
            if (this.lstAccount.SelectedItems.Count > 0)
            {
                btnKhoiPhuc.Enabled = true;
                btnDeleteAccount.Enabled = true;
                txtPassword.ReadOnly = true;
                this.btnEditAccount.Visible = true;
                this.btnAddAccount.Visible = false;
                ListViewItem lvw = lstAccount.SelectedItems[0];
                AccountDTO sp = (AccountDTO)lvw.Tag;
                txtNameAcount.Text = "03060"+sp.ID.ToString();
                txtPassword.Text = sp.PassWord;
                txtHoTen.Text = sp.Name;
                txtCMND.Text = sp.PassPort;
                txtNoiSinh.Text = sp.PlaceOfBirth;
                txtTelephone.Text = sp.Telephone;
                txtAddress.Text = sp.Address;
                if (sp.Right == 0)
                {
                    this.radAd.Checked = true;
                }
                else
                    this.radNguoiDung.Checked = true;
                if (sp.Status == 0)
                {
                    this.radAnAccount.Checked = true;
                }
                else
                    this.radHienAccount.Checked = true;
            }
        }
        void DeleteTextAccount()
        {
            btnDeleteAccount.Enabled = false;
            txtPassword.Enabled = false;
            this.btnEditAccount.Visible = false;
            this.btnAddAccount.Visible = true;
            txtNameAcount.ReadOnly = false;
            txtNameAcount.Text = "";
            txtPassword.Text = "";
            txtHoTen.Text = "";
            txtTelephone.Text = "";
            txtCMND.Text = "";
            txtAddress.Text = "";
            radAd.Checked = false;
            radNguoiDung.Checked = true;
            radHienAccount.Checked = true;
            radAnAccount.Checked = false;
            txtNoiSinh.Text = "";
            btnDeleteAccount.Enabled = false;

            btnKhoiPhuc.Enabled = false;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstAccount.SelectedItems.Count > 0)
                {
                    ListViewItem lvw = lstAccount.SelectedItems[0];
                    AccountDTO sp = (AccountDTO)lvw.Tag;
                    if (sp.ID == Program.sAccount.ID)
                    {
                        MessageBox.Show("Bạn không thể sử dụng chức năng này với chính bạn.", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        frm_XacNhan frm_XN = new frm_XacNhan("Bạn vui lòng nhập mật khẩu để xác nhận thao tác này!", Program.sAccount);
                        if (frm_XN.ShowDialog() == DialogResult.OK)
                        {
                            if (AccountBUS.IsLogin(Program.sAccount.ID, frm_XN.txtXacNhap.Text))
                            {
                                if (!BillBUS.IsExistAccountInBill(sp.ID))
                                {
                                    if (AccountBUS.DeleteAccount(sp) == true)
                                    {
                                        MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK);
                                        ShowAccout();
                                        DeleteTextAccount();
                                        txtNameAcount.ReadOnly = false;
                                        this.btnEditAccount.Visible = false;
                                        this.btnAddAccount.Visible = true;
                                        btnDeleteAccount.Enabled = false;
                                    }
                                    else
                                        MessageBox.Show("Xóa tài khoản thất bại.", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                    MessageBox.Show("Tài khoản này đang hoạt động với hệ thống. Nên bạn không thể xóa tài khoản này khỏi hệ thống.", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                                MessageBox.Show("Bạn đã nhập sai mật khẩu, vui lòng quay lại sau.", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn chưa chọn được tài khoản nào.", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì, bạn vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            DeleteTextAccount();

        }

        private void btnOutAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPriceDrink_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void frm_QuanLy_Load(object sender, EventArgs e)
        {
            cbTypeDrink.ContextMenu = new ContextMenu();
            cbLocLoaiSP.ContextMenu = new ContextMenu();
            txtPassword.Enabled = false;
            btnKhoiPhuc.Enabled = false;
            LoadListBill();
            List<TypeDrinkDTO> listtype = TypeDrinkBUS.GetAllListTypeDrink();
            cbLocLoaiSP.DataSource = listtype;
            cbLocLoaiSP.ValueMember = "ID";
            cbLocLoaiSP.DisplayMember = "NameType";
            if (cbLocLoaiSP.SelectedItem != null)
                LoadDrinkListByTypeDrinkID(Convert.ToInt32(cbLocLoaiSP.SelectedValue));
        }

        private void LoadListTypeDrink(ComboBox cbx)
        {
            List<TypeDrinkDTO> listtype = TypeDrinkBUS.GetAllListTypeDrink();
            cbx.DataSource = listtype;
            cbx.ValueMember = "ID";
            cbx.DisplayMember = "NameType";
        }

        private void LoadListBill()
        {
            lstRevenue.Items.Clear();
            List<BillDTO> list = BUS.BillBUS.GetAllListBill();
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = "#" + (i + 1).ToString();
                listitem.SubItems.Add("HD00"+list[i].ID.ToString());
                listitem.SubItems.Add(list[i].Total.ToString("###,### VNĐ"));
                listitem.SubItems.Add(list[i].CreateDay.ToString());
                listitem.SubItems.Add(AccountBUS.GetNameByAccount(list[i].Employ).ToString());
                listitem.Tag = list[i];
                lstRevenue.Items.Add(listitem);
            }
        }

        private void btnSearchDrink_Click(object sender, EventArgs e)
        {
            lstDrink.Items.Clear();
            List<DrinkDTO> list = DrinkBUS.GeDrinkByName(txtSearchDrink.Text);
            CreateListDrink(list);
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            rptThongKe rptThongKe = new rptThongKe();
            DateTime Time = DateTime.Now;
            List<BillDTO> lstBill = BUS.BillBUS.GetListBillInAboutTime(dtpFromDate.Value, dtpToDate.Value);
            if (lstBill.Count > 0)
            {
                rptThongKe.XuatThongKeTheoThang(lstBill, dtpFromDate.Value, dtpToDate.Value, DateTime.Now, Program.sAccount.Name);
                rptThongKe.ShowDialog();
            }
            else MessageBox.Show("Hiện tại trong khoảng thời gian này chưa có hóa đơn nào được tạo.", "Thông báo", MessageBoxButtons.OK); 
            
        }

        private void cbLoaiThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi load loại loại thức uống thì sẽ gán loại theo cái thức uống.
            int id = 0;
            if (cbLocLoaiSP.SelectedItem == null)
                return;
            TypeDrinkDTO typedrink = cbLocLoaiSP.SelectedItem as TypeDrinkDTO;
            id = typedrink.ID;
            LoadDrinkListByTypeDrinkID(id);
        }

        void LoadDrinkListByTypeDrinkID(int id)
        {
            lstDrink.Items.Clear();
            //load thức uống theo mã loại thức uống
            List<DrinkDTO> listdrink = DrinkBUS.GetListDrinkByIDTypeDrink(id,-1);
            for (int i = 0; i < listdrink.Count; i++)
            {
                ListViewItem listitem = new ListViewItem();
                listitem.Text = "#"+(i+1).ToString();
                listitem.SubItems.Add(listdrink[i].NameDrinks);
                if (listdrink[i].PriceBasic == 0)
                {
                     listitem.SubItems.Add("Miễn phí");
                }
                else listitem.SubItems.Add(listdrink[i].PriceBasic.ToString("0,000 VNĐ"));

                if (listdrink[i].SalePrice == listdrink[i].PriceBasic)
                listitem.SubItems.Add("Không có chương trình khuyến mãi");
                else
                {
                    int phantram = (int)((listdrink[i].SalePrice * 100) / listdrink[i].PriceBasic);
                    listitem.SubItems.Add("Đang giảm" + phantram + " %");
                }
                if (listdrink[i].Status == 1)
                {
                    listitem.SubItems.Add("Đang họat động");
                }
                else
                {
                    listitem.SubItems.Add("Ngưng bán");
                }
                listitem.SubItems.Add("SP00" + listdrink[i].ID);
                listitem.Tag = listdrink[i];
                lstDrink.Items.Add(listitem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txtNameAcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstAccount.SelectedItems.Count > 0)
                {
                    AccountDTO acc = lstAccount.SelectedItems[0].Tag as AccountDTO;
                    frm_XacNhan frm_XN = new frm_XacNhan("Bạn vui lòng nhập mật khẩu để xác nhận thao tác này!", Program.sAccount);
                    if (frm_XN.ShowDialog() == DialogResult.OK)
                    {
                        if (AccountBUS.IsLogin(Program.sAccount.ID, frm_XN.txtXacNhap.Text))
                        {
                           if (AccountBUS.ResetAccount(acc.ID))
                            {
                                ShowAccout();
                                MessageBox.Show("Đã cập nhật reset thành công", "Thông báo", MessageBoxButtons.OK);
                                DeleteTextAccount();
                                txtNameAcount.ReadOnly = false;
                                this.btnEditAccount.Visible = false;
                                this.btnAddAccount.Visible = true;
                                btnDeleteAccount.Enabled = false;
                            }
                            else
                                MessageBox.Show("Reset mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("Bạn đã nhập sai mật khẩu, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn tài khoản để thực hiện chức năng này!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì bạn vui lòng quay lại sau nhé", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNameAcount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // KeyCode dành cho text nhập số
            if ((Convert.ToInt32(e.KeyChar) >= 48 && Convert.ToInt32(e.KeyChar) <= 57) || Convert.ToInt32(e.KeyChar) == 8)
            {
                e.Handled = false;
            }
            else e.Handled = true;

        }

        private void cbTypeDrink_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTypeDrinkName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 22)
                e.Handled = true;
        }

        private void txtTableName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 22)
                e.Handled = true;
        }

        private void txtPriceDrink_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // KeyCode dành cho text nhập số
            if ((Convert.ToInt32(e.KeyChar) >= 48 && Convert.ToInt32(e.KeyChar) <= 57) || Convert.ToInt32(e.KeyChar) == 8)
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void cbTypeDrink_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void lstRevenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstRevenue.SelectedItems.Count > 0)
                {
                    BillDTO bill = lstRevenue.SelectedItems[0].Tag as BillDTO;
                    DialogResult kq = MessageBox.Show("Bạn có muốn xem lại hóa đơn HD00"+bill.ID+" này có gì không?","Thông báo",MessageBoxButtons.OKCancel);
                    if(kq == DialogResult.OK)
                    {
                        rptThanhToan frm_TToan = new rptThanhToan();
                        frm_TToan.XuatHoaDon(bill.ID, "HÓA ĐƠN ĐÃ THANH TOÁN", "Bàn số " + bill.Idtable, AccountBUS.GetNameByAccount(bill.Employ), bill.CreateDay, bill.Total.ToString(), "0", "0",false);
                        //
                        frm_TToan.ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang bảo trì, thử lại.");
            }
        }

        
    }
}
