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
            LoadData(); // Tự động gọi khi mở Form
        }

        // Hàm lấy danh sách điện thoại từ SQL lên bảng (DataGridView)
        public void LoadData()
        {
            string sql = "SELECT MaDT AS [Mã], TenDT AS [Tên Máy], GiaBan AS [Giá], SoLuong AS [Kho], HangSX AS [Hãng] FROM DienThoai";
            DataTable dt = kn.LayDuLieu(sql);
            dgvDienThoai.DataSource = dt; // dgvDienThoai là tên của DataGridView trên giao diện
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
                LoadData(); // Sau khi đăng nhập thì hiện danh sách
            }
            else { MessageBox.Show("Sai tài khoản!"); }
        }
    }
}
