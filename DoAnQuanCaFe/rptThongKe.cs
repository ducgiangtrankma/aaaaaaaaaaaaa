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
    public partial class rptThongKe : Form
    {
        public rptThongKe()
        {
            InitializeComponent();
        }

        private void rptThongKe_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void XuatThongKeTheoThang(List<BillDTO> lstBill, DateTime ThoiGianTu, DateTime ThoiGianDen, DateTime ThoiGianLap, string NhanVien)
        {
            if (lstBill.Count > 0)
            {
                double TongDoanhThuThang = TinhTongDoanhThu(lstBill);

                reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanCafe.rptThongKe.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtThongKe", lstBill));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("paraThoiGian", ThoiGianLap.ToString(), false));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("paraThoiGianTu", ThoiGianTu.ToString("dd/MM/yyyy"), false));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("paraThoiGianDen", ThoiGianDen.ToString("dd/MM/yyyy"), false));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("paraNV", NhanVien, false));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("paraTongTien", TongDoanhThuThang.ToString("0,0 VNĐ"), false));

                this.reportViewer1.RefreshReport();
            }

        }

        private double TinhTongDoanhThu(List<BillDTO> lstBill)
        {
            double Tong = 0;
            foreach (BillDTO bill in lstBill)
            {
                Tong += bill.Total;
            }
            return Tong;
        }
    }
}
