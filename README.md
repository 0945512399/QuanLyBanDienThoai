# Đồ án Tốt nghiệp: Hệ thống Quản lý Bán Điện thoại

## 📌 Giới thiệu dự án
Dự án được xây dựng nhằm mục đích quản lý hoạt động kinh doanh tại các cửa hàng bán lẻ điện thoại. Hệ thống hỗ trợ nhân viên và quản trị viên thực hiện các nghiệp vụ từ nhập liệu, tìm kiếm đến thống kê báo cáo.

## 🛠 Công nghệ sử dụng
* **Ngôn ngữ:** C# (WinForms)
* **Hệ quản trị CSDL:** SQL Server
* **Công cụ:** Visual Studio 2022, Git/GitHub
* **Thư viện:** System.Data.SqlClient

## ✨ Các chức năng chính
1.  **Đăng nhập hệ thống:** Bảo mật quyền truy cập cho Admin và Nhân viên.
2.  **Quản lý danh mục:** * Xem danh sách điện thoại hiện có.
    * Thêm mới sản phẩm vào kho.
    * Sửa thông tin (Giá, Số lượng, Hãng sản xuất).
    * Xóa sản phẩm khỏi hệ thống (có xác nhận).
3.  **Tìm kiếm thông minh:** Tìm kiếm nhanh theo tên máy hoặc hãng sản xuất ngay khi đang gõ.
4.  **Thống kê báo cáo:** * Tính tổng số lượng máy trong kho.
    * Tính tổng giá trị hàng hóa hiện có.

## 📁 Cấu trúc thư mục
* `/QuanLyBanDienThoai`: Chứa mã nguồn C# (.cs, .sln).
* `/Database`: Chứa script SQL tạo bảng và dữ liệu mẫu.
* `KetNoi.cs`: Lớp xử lý kết nối SQL Server dùng chung.

## 🚀 Hướng dẫn cài đặt
1.  Tải mã nguồn về máy.
2.  Chạy script trong file `Database/QuanLyBanDienThoai.sql` trên SQL Server.
3.  Mở file `.sln` bằng Visual Studio.
4.  Thay đổi chuỗi kết nối trong `KetNoi.cs` cho phù hợp với Server của bạn.
5.  Ấn **F5** để chạy chương trình.

---
**Sinh viên thực hiện:** Đồ án tốt nghiệp Đại học Mở Hà Nội (EHOU).
