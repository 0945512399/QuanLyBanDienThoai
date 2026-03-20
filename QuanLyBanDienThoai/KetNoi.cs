using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanDienThoai
{
    public class KetNoi
    {
        // Chuỗi kết nối (Thay đổi tên Server cho đúng với máy của bạn)
        private string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanDienThoai;Integrated Security=True";
        
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }

        // Hàm thực thi truy vấn (Dùng cho Thêm, Sửa, Xóa)
        public bool ThucThi(string sql)
        {
            using (SqlConnection con = GetConnection())
            {
                try {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    return true;
                } catch { return false; }
            }
        }

        // Hàm lấy dữ liệu (Dùng cho hiển thị lên Bảng/GridView)
        public DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
