using DTO;
using Microsoft.Reporting.WinForms;
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
    public partial class rptThanhToan : Form
    {
        public rptThanhToan()
        {
            InitializeComponent();
        }

        private void reportThanhToan_Load(object sender, EventArgs e)
        {
            //XuatHoaDon(5, "adfa", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), Convert.ToInt32("4000"), "5000", "6000");
            this.rptXuatHD.RefreshReport();
        }

        public void XuatHoaDon(int MaHD,string TenHD, string Ban, string nhanvien, DateTime thoigian, string tongtien, string tienkhachhang, string tienton,bool xemlaihoadon)
        {
             List<MenuDTO> lstDrink = BUS.MenuBUS.GetListMenuByIDBill(MaHD);
            if(!xemlaihoadon)
                lstDrink = BUS.MenuBUS.GetReviewBill(MaHD);

            rptXuatHD.LocalReport.ReportEmbeddedResource = "QuanLyQuanCafe.rptThanhToan.rdlc";
            if (tienton != "0")
            tienton = string.Format("{0:0,0}", Convert.ToDouble(tienton).ToString("0,0"));
            if (tienkhachhang != "0")
            tienkhachhang = string.Format("{0:0,0}", "" + Convert.ToDouble(tienkhachhang).ToString("0,0") + "");
            if (tongtien != "0")
            tongtien = string.Format("{0:0,0}", Convert.ToDouble(tongtien).ToString("0,0"));
            rptXuatHD.LocalReport.DataSources.Add(new ReportDataSource("dtThanhToan", lstDrink));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraHD", "HD00" + MaHD.ToString(), false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraNV", nhanvien,false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraThoiGian", thoigian.ToString(), false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraTongTien",tongtien , false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("parasTienKhachTra", tienkhachhang, false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraTienTon",tienton, false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraNameBill", TenHD, false));
            rptXuatHD.LocalReport.SetParameters(new ReportParameter("paraBan", Ban, false));



            this.rptXuatHD.RefreshReport();
        }
    }
}
