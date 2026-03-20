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
        }

        // Sự kiện khi nhấn nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            string sql = "SELECT * FROM NguoiDung WHERE TenDangNhap = '" + user + "' AND MatKhau = '" + pass + "'";
            DataTable dt = kn.LayDuLieu(sql);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công! Chào mừng " + dt.Rows[0]["HoTen"].ToString());
                // Chuyển sang Form chính của đồ án tại đây
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
