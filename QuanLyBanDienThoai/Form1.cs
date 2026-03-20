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

        // Bước 1: Khi nhấn vào bảng, hiển thị dữ liệu lên các ô TextBox
        private void dgvDienThoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDienThoai.Rows[e.RowIndex];
                txtMaDT.Text = row.Cells[0].Value.ToString();
                txtTenDT.Text = row.Cells[1].Value.ToString();
                txtGiaBan.Text = row.Cells[2].Value.ToString();
                txtSoLuong.Text = row.Cells[3].Value.ToString();
                txtHangSX.Text = row.Cells[4].Value.ToString();
                
                // Khóa ô Mã (không cho sửa Mã vì là Khóa chính)
                txtMaDT.ReadOnly = true;
            }
        }

        // Bước 2: Chức năng Sửa thông tin
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = string.Format("UPDATE DienThoai SET TenDT = N'{0}', GiaBan = {1}, SoLuong = {2}, HangSX = N'{3}' WHERE MaDT = '{4}'",
                                        txtTenDT.Text, txtGiaBan.Text, txtSoLuong.Text, txtHangSX.Text, txtMaDT.Text);

            if (kn.ThucThi(sql))
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                LoadData();
                txtMaDT.ReadOnly = false; // Mở lại ô Mã cho lần thêm tiếp theo
            }
            else { MessageBox.Show("Lỗi khi cập nhật dữ liệu!"); }
        }

        // Các hàm cũ (Xóa, Thêm...) giữ nguyên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ma = dgvDienThoai.CurrentRow.Cells[0].Value.ToString();
            string sql = "DELETE FROM DienThoai WHERE MaDT = '" + ma + "'";
            if (kn.ThucThi(sql)) { MessageBox.Show("Đã xóa!"); LoadData(); }
        }
    }
}
