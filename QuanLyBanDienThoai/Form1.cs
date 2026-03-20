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

        // Sự kiện Tìm kiếm nhanh khi gõ chữ vào ô txtSearch
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            // Tìm kiếm theo Tên máy hoặc Hãng sản xuất
            string sql = "SELECT MaDT AS [Mã], TenDT AS [Tên Máy], GiaBan AS [Giá], SoLuong AS [Kho], HangSX AS [Hãng] " +
                         "FROM DienThoai WHERE TenDT LIKE N'%" + keyword + "%' OR HangSX LIKE N'%" + keyword + "%'";
            
            dgvDienThoai.DataSource = kn.LayDuLieu(sql);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = '" + user + "' AND MatKhau = '" + pass + "'";
            DataTable dt = kn.LayDuLieu(sql);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                LoadData();
            }
            else { MessageBox.Show("Sai tài khoản!"); }
        }
    }
}
