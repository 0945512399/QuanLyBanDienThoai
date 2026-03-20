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

        // Chức năng Xóa Điện thoại đang chọn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDienThoai.CurrentRow != null)
            {
                // Lấy mã điện thoại từ cột đầu tiên của dòng đang chọn
                string ma = dgvDienThoai.CurrentRow.Cells[0].Value.ToString();

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa máy " + ma + " không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string sql = "DELETE FROM DienThoai WHERE MaDT = '" + ma + "'";
                    if (kn.ThucThi(sql))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadData(); // Cập nhật lại bảng
                    }
                    else { MessageBox.Show("Lỗi khi xóa dữ liệu!"); }
                }
            }
            else { MessageBox.Show("Vui lòng chọn một dòng để xóa!"); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = string.Format("INSERT INTO DienThoai VALUES ('{0}', N'{1}', {2}, {3}, N'{4}')", 
                                        txtMaDT.Text, txtTenDT.Text, txtGiaBan.Text, txtSoLuong.Text, txtHangSX.Text);
            if (kn.ThucThi(sql)) { MessageBox.Show("Thêm thành công!"); LoadData(); }
        }
    }
}
