CREATE DATABASE QuanLyBanDienThoai;
GO
USE QuanLyBanDienThoai;
GO

CREATE TABLE DienThoai (
    MaDT NVARCHAR(20) PRIMARY KEY,
    TenDT NVARCHAR(100),
    GiaBan DECIMAL(18, 2),
    SoLuong INT,
    HangSX NVARCHAR(50)
);

CREATE TABLE KhachHang (
    MaKH NVARCHAR(20) PRIMARY KEY,
    TenKH NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    DiaChi NVARCHAR(200)
);

CREATE TABLE HoaDon (
    MaHD NVARCHAR(20) PRIMARY KEY,
    NgayBan DATETIME,
    MaKH NVARCHAR(20),
    TongTien DECIMAL(18, 2),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- 4. Bảng Người dùng (Đăng nhập)
CREATE TABLE NguoiDung (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50),
    HoTen NVARCHAR(100),
    Quyen NVARCHAR(20) -- Admin hoặc Nhân viên
);

-- Thêm tài khoản mẫu
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen) 
VALUES ('admin', 'admin123', 'Quan Tri Vien', 'Admin');
