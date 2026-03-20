using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanDienThoai
{
    public partial class Form1 : Form
    {
        KetNoi kn = new KetNoi();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            string sql = "SELECT MaDT AS [Mã], TenDT AS [Tên Máy], GiaBan AS [Giá], SoLuong AS [Kho], HangSX AS [Hãng] FROM DienThoai";
            dgvDienThoai.DataSource = kn.LayDuLieu(sql);
            ThongKe(); // Tự động cập nhật con số mỗi khi dữ liệu thay đổi
        }

        // Chức năng Thống kê báo cáo nhanh
        public void ThongKe()
        {
            // Lấy tổng số lượng và tổng giá trị từ SQL
            string sql = "SELECT SUM(SoLuong) as TongSL, SUM(SoLuong * GiaBan) as TongGiaTri FROM DienThoai";
            DataTable dt = kn.LayDuLieu(sql);

            if (dt.Rows.Count > 0 && dt.Rows[0]["TongSL"] != DBNull.Value)
            {
                lblTongSoLuong.Text = "Tổng máy trong kho: " + dt.Rows[0]["TongSL"].ToString();
                lblTongGiaTri.Text = "Tổng giá trị: " + string.Format("{0:N0}", dt.Rows[0]["TongGiaTri"]) + " VNĐ";
            }
            else
            {
                lblTongSoLuong.Text = "Tổng máy trong kho: 0";
                lblTongGiaTri.Text = "Tổng giá trị: 0 VNĐ";
            }
        }

        // Các hàm cũ (Add, Edit, Delete...) vẫn giữ nguyên để đảm bảo chương trình chạy tốt
    }
}
