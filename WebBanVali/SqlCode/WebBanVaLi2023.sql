CREATE DATABASE [QLBanVaLi]
GO 
USE [QLBanVaLi]
CREATE TABLE [dbo].[tUser] (
	[username] [char](100) PRIMARY KEY ,
    [MatKhau] [char](100) NOT NULL
);

CREATE TABLE [dbo].[tKhachHang] (
    [MaKhachHang] INT PRIMARY KEY  IDENTITY(1,1),
    [TenKhachHang] NVARCHAR(50) NOT NULL,
    [MaUser] [char](100) NOT NULL, 
    FOREIGN KEY ([MaUser]) REFERENCES [dbo].[tUser]([username])
);

CREATE TABLE [dbo].[tDanhMucSP] (
    [MaDM] INT PRIMARY KEY  IDENTITY(1,1), 
    [TenDM] NVARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[tChiTietSanPham] (
    [MaChiTietSP] INT PRIMARY KEY  IDENTITY(1,1),
    [TenChiTietSP] NVARCHAR(50) NOT NULL,
    [MaDM] INT,
    FOREIGN KEY ([MaDM]) REFERENCES [dbo].[tDanhMucSP]([MaDM]),
	[DonGiaBan] [float] NULL,
	[GiamGia] [float] NULL,
	[SLTon] [int] NULL,
	[KichThuoc] [char](25) NULL,
	[MauSac] [char](25) NULL,
	[AnhDaiDien] [char](100) NULL
);

CREATE TABLE [dbo].[tHoaDonBan] (
    [MaHoaDon] INT PRIMARY KEY  IDENTITY(1,1),
    [NgayBan] DATE NOT NULL,
    [MaKhachHang] INT,
    FOREIGN KEY ([MaKhachHang]) REFERENCES [dbo].[tKhachHang]([MaKhachHang])
);

CREATE TABLE [dbo].[tChiTietHDB] (
    [MaChiTietHDB] INT PRIMARY KEY  IDENTITY(1,1), 
    [MaHoaDon] INT,
    [MaChiTietSP] INT,
    [SoLuong] INT NOT NULL,
    [DonGia] FLOAT NOT NULL,
    FOREIGN KEY ([MaHoaDon]) REFERENCES [dbo].[tHoaDonBan]([MaHoaDon]),
    FOREIGN KEY ([MaChiTietSP]) REFERENCES [dbo].[tChiTietSanPham]([MaChiTietSP])
);

INSERT INTO [dbo].[tUser] ([username], [MatKhau]) VALUES
('user1', 'password1'),
('user2', 'password2'),
('user3', 'password3');

INSERT INTO [dbo].[tKhachHang] ([TenKhachHang], [MaUser]) VALUES
('KhachHang1', 'user1'),
('KhachHang2', 'user2'),
('KhachHang3', 'user3');

INSERT INTO [dbo].[tDanhMucSP] ([TenDM]) VALUES
('DanhMuc1'),
('DanhMuc2'),
('DanhMuc3');

INSERT INTO [dbo].[tChiTietSanPham] ([TenChiTietSP], [MaDM], [DonGiaBan], [GiamGia], [SLTon], [KichThuoc], [MauSac], [AnhDaiDien]) VALUES
('SP1', 1, 100.0, 0.1, 50, 'S', 'Red', 'sp1.jpg'),
('SP2', 2, 150.0, 0.2, 30, 'M', 'Blue', 'sp2.jpg'),
('SP3', 3, 200.0, 0.0, 20, 'L', 'Green', 'sp3.jpg');

INSERT INTO [dbo].[tHoaDonBan] ([NgayBan], [MaKhachHang]) VALUES
('2023-01-01', 1),
('2023-02-01', 2),
('2023-03-01', 3);

INSERT INTO [dbo].[tChiTietHDB] ([MaHoaDon], [MaChiTietSP], [SoLuong], [DonGia]) VALUES
(1, 1, 5, 100.0),
(2, 2, 3, 150.0),
(3, 3, 2, 200.0);
