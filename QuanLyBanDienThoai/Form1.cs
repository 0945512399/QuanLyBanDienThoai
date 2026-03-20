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
        }

        // Chức năng Thêm mới Điện thoại
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMaDT.Text;
            string ten = txtTenDT.Text;
            string gia = txtGiaBan.Text;
            string sl = txtSoLuong.Text;
            string hang = txtHangSX.Text;

            // Câu lệnh SQL Thêm dữ liệu
            string sql = string.Format("INSERT INTO DienThoai VALUES ('{0}', N'{1}', {2}, {3}, N'{4}')", 
                                        ma, ten, gia, sl, hang);

            if (kn.ThucThi(sql))
            {
                MessageBox.Show("Thêm điện thoại thành công!");
                LoadData(); // Tải lại bảng để thấy dữ liệu mới
            }
            else
            {
                MessageBox.Show("Lỗi: Kiểm tra lại mã trùng hoặc định dạng số!");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            string sql = "SELECT MaDT AS [Mã], TenDT AS [Tên Máy], GiaBan AS [Giá], SoLuong AS [Kho], HangSX AS [Hãng] " +
                         "FROM DienThoai WHERE TenDT LIKE N'%" + keyword + "%' OR HangSX LIKE N'%" + keyword + "%'";
            dgvDienThoai.DataSource = kn.LayDuLieu(sql);
        }
    }
}
