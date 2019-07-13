USE [master]
GO
/****** Object:  Database [Quanly_quanan]    Script Date: 07/13/2019 12:12:05 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Quanly_quanan')
BEGIN
CREATE DATABASE [Quanly_quanan] 
GO
ALTER DATABASE [Quanly_quanan] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quanly_quanan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quanly_quanan] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Quanly_quanan] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Quanly_quanan] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Quanly_quanan] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Quanly_quanan] SET ARITHABORT OFF
GO
ALTER DATABASE [Quanly_quanan] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Quanly_quanan] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Quanly_quanan] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Quanly_quanan] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Quanly_quanan] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Quanly_quanan] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Quanly_quanan] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Quanly_quanan] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Quanly_quanan] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Quanly_quanan] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Quanly_quanan] SET  ENABLE_BROKER
GO
ALTER DATABASE [Quanly_quanan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Quanly_quanan] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Quanly_quanan] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Quanly_quanan] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Quanly_quanan] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Quanly_quanan] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Quanly_quanan] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Quanly_quanan] SET  READ_WRITE
GO
ALTER DATABASE [Quanly_quanan] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Quanly_quanan] SET  MULTI_USER
GO
ALTER DATABASE [Quanly_quanan] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Quanly_quanan] SET DB_CHAINING OFF
GO
USE [Quanly_quanan]
GO
/****** Object:  ForeignKey [FK_Taikhoan_Quyentruycap]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Taikhoan_Quyentruycap]') AND parent_object_id = OBJECT_ID(N'[dbo].[Taikhoan]'))
ALTER TABLE [dbo].[Taikhoan] DROP CONSTRAINT [FK_Taikhoan_Quyentruycap]
GO
/****** Object:  ForeignKey [fk_Sanpham_Danhmuc]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Sanpham_Danhmuc]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sanpham]'))
ALTER TABLE [dbo].[Sanpham] DROP CONSTRAINT [fk_Sanpham_Danhmuc]
GO
/****** Object:  ForeignKey [fk_Hoadon_Ban]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Hoadon_Ban]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon] DROP CONSTRAINT [fk_Hoadon_Ban]
GO
/****** Object:  ForeignKey [fk_Taikhoan_matk]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Taikhoan_matk]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon] DROP CONSTRAINT [fk_Taikhoan_matk]
GO
/****** Object:  ForeignKey [fk_Chitiethoadon_Hoadon]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Hoadon]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon] DROP CONSTRAINT [fk_Chitiethoadon_Hoadon]
GO
/****** Object:  ForeignKey [fk_Chitiethoadon_Sanpham]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Sanpham]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon] DROP CONSTRAINT [fk_Chitiethoadon_Sanpham]
GO
/****** Object:  Table [dbo].[Chitiethoadon]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Hoadon]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon] DROP CONSTRAINT [fk_Chitiethoadon_Hoadon]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Sanpham]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon] DROP CONSTRAINT [fk_Chitiethoadon_Sanpham]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]') AND type in (N'U'))
DROP TABLE [dbo].[Chitiethoadon]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Hoadon_Ban]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon] DROP CONSTRAINT [fk_Hoadon_Ban]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Taikhoan_matk]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon] DROP CONSTRAINT [fk_Taikhoan_matk]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Hoadon__tinhtran__1CF15040]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Hoadon] DROP CONSTRAINT [DF__Hoadon__tinhtran__1CF15040]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hoadon]') AND type in (N'U'))
DROP TABLE [dbo].[Hoadon]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Sanpham_Danhmuc]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sanpham]'))
ALTER TABLE [dbo].[Sanpham] DROP CONSTRAINT [fk_Sanpham_Danhmuc]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sanpham]') AND type in (N'U'))
DROP TABLE [dbo].[Sanpham]
GO
/****** Object:  Table [dbo].[Taikhoan]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Taikhoan_Quyentruycap]') AND parent_object_id = OBJECT_ID(N'[dbo].[Taikhoan]'))
ALTER TABLE [dbo].[Taikhoan] DROP CONSTRAINT [FK_Taikhoan_Quyentruycap]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Taikhoan]') AND type in (N'U'))
DROP TABLE [dbo].[Taikhoan]
GO
/****** Object:  Table [dbo].[Quyentruycap]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quyentruycap]') AND type in (N'U'))
DROP TABLE [dbo].[Quyentruycap]
GO
/****** Object:  Table [dbo].[Danhmuc]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Danhmuc]') AND type in (N'U'))
DROP TABLE [dbo].[Danhmuc]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 07/13/2019 12:12:09 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Ban__tinhtrang__08EA5793]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Ban] DROP CONSTRAINT [DF__Ban__tinhtrang__08EA5793]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ban]') AND type in (N'U'))
DROP TABLE [dbo].[Ban]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ban]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ban](
	[ma_ban] [varchar](10) NOT NULL,
	[ten_ban] [varchar](10) NOT NULL,
	[tinhtrang] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ma_ban] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'DEPALDCNQL', N'C1', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'FCDLIIJGDB', N'B4', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'FDAOVBIHKN', N'A8', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'FKKVQEOPLD', N'B5', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'GBEJAGMNUM', N'A9', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'GEJNQAECQL', N'A1', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'GESCOKELEE', N'D1', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'GTAFVUMKDH', N'B8', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'IHEJELRNMR', N'C9', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'IIQPNJLCIE', N'C4', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'IJQBQTFKIL', N'C7', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'IKCQJFPUST', N'A5', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'KALKIETRGG', N'C8', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'KQOEBJKHHF', N'A2', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'LOIQICIRAM', N'C2', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'LSRLDJPJQO', N'C3', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'LSTAJNALAL', N'A6', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'NFRQFHFHHQ', N'C6', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'NKJLFQUBVV', N'A3', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'OFKLUVRGJB', N'B1', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'PCRJFIBEJF', N'B2', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'QANTDTFNSA', N'A7', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'SRCDUIUKRR', N'C5', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'UCVQRPGLRC', N'A4', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'UKHKCVGGTG', N'B7', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'VBBFOPTIOC', N'B6', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'VJLFKQAPVO', N'B3', 0)
INSERT [dbo].[Ban] ([ma_ban], [ten_ban], [tinhtrang]) VALUES (N'VNTRAVVOUJ', N'B9', 0)
/****** Object:  Table [dbo].[Danhmuc]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Danhmuc]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Danhmuc](
	[ma_danhmuc] [varchar](10) NOT NULL,
	[ten_danhmuc] [nvarchar](255) NOT NULL,
	[mota_danhmuc] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_danhmuc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Danhmuc] ([ma_danhmuc], [ten_danhmuc], [mota_danhmuc]) VALUES (N'PIIJGENMTE', N'Đồ ăn', N'Đồ ăn')
INSERT [dbo].[Danhmuc] ([ma_danhmuc], [ten_danhmuc], [mota_danhmuc]) VALUES (N'PJCHPGHVLQ', N'Đồ uống', N'Đồ uống')
/****** Object:  Table [dbo].[Quyentruycap]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Quyentruycap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Quyentruycap](
	[ma_quyen] [int] IDENTITY(1,1) NOT NULL,
	[ten_quyen] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_quyen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Quyentruycap] ON
INSERT [dbo].[Quyentruycap] ([ma_quyen], [ten_quyen]) VALUES (1, N'Quản trị')
INSERT [dbo].[Quyentruycap] ([ma_quyen], [ten_quyen]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[Quyentruycap] OFF
/****** Object:  Table [dbo].[Taikhoan]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Taikhoan]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Taikhoan](
	[ma_taikhoan] [varchar](255) NOT NULL,
	[ten_dangnhap] [nvarchar](255) NOT NULL,
	[matkhau] [varchar](255) NOT NULL,
	[ma_quyen] [int] NULL,
	[tennhanvien] [nvarchar](255) NOT NULL,
	[sodienthoai] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_taikhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Taikhoan] ([ma_taikhoan], [ten_dangnhap], [matkhau], [ma_quyen], [tennhanvien], [sodienthoai]) VALUES (N'0e59de19-2f71-40a9-b75a-00527d7bad00', N'User1', N'6b908b785fdba05a6446347dae08d8c5', 1, N'Giáp Hoàng ', N'0989898989')
INSERT [dbo].[Taikhoan] ([ma_taikhoan], [ten_dangnhap], [matkhau], [ma_quyen], [tennhanvien], [sodienthoai]) VALUES (N'e3f370c1-efc0-41bc-8fa2-93ca94c3c182', N'User2', N'a09bccf2b2963982b34dc0e08d8b582a', 1, N'Giáp Hoàng ', N'0989898989')
/****** Object:  Table [dbo].[Sanpham]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sanpham]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sanpham](
	[ma_sanpham] [varchar](10) NOT NULL,
	[ten_sanpham] [nvarchar](255) NOT NULL,
	[mota_sanpham] [nvarchar](max) NOT NULL,
	[dongia] [float] NOT NULL,
	[ma_danhmuc] [varchar](10) NULL,
	[tendonvi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_sanpham] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Sanpham] ([ma_sanpham], [ten_sanpham], [mota_sanpham], [dongia], [ma_danhmuc], [tendonvi]) VALUES (N'AU0814', N'Gà', N'Gà ngon', 1000000, N'PIIJGENMTE', N'Đĩa')
INSERT [dbo].[Sanpham] ([ma_sanpham], [ten_sanpham], [mota_sanpham], [dongia], [ma_danhmuc], [tendonvi]) VALUES (N'DM1574', N'Lợn', N'Lợn', 2000000, N'PIIJGENMTE', N'Đĩa')
INSERT [dbo].[Sanpham] ([ma_sanpham], [ten_sanpham], [mota_sanpham], [dongia], [ma_danhmuc], [tendonvi]) VALUES (N'IH3341', N'Rượu', N'Rượu', 1500000, N'PJCHPGHVLQ', N'Chai')
INSERT [dbo].[Sanpham] ([ma_sanpham], [ten_sanpham], [mota_sanpham], [dongia], [ma_danhmuc], [tendonvi]) VALUES (N'SE7183', N'Bia', N'Bia', 500000, N'PJCHPGHVLQ', N'Chai')
INSERT [dbo].[Sanpham] ([ma_sanpham], [ten_sanpham], [mota_sanpham], [dongia], [ma_danhmuc], [tendonvi]) VALUES (N'SI7303', N'Nước ngọt', N'Nước ngọt', 100000, N'PJCHPGHVLQ', N'Chai')
INSERT [dbo].[Sanpham] ([ma_sanpham], [ten_sanpham], [mota_sanpham], [dongia], [ma_danhmuc], [tendonvi]) VALUES (N'TG7284', N'Bò', N'Bò', 1000000, N'PIIJGENMTE', N'Đĩa')
/****** Object:  Table [dbo].[Hoadon]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hoadon]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Hoadon](
	[ma_hoadon] [varchar](10) NOT NULL,
	[ngay_dat] [nvarchar](255) NOT NULL,
	[ngay_thanhtoan] [nvarchar](255) NULL,
	[tinhtrang] [bit] NOT NULL DEFAULT ((0)),
	[khachhang] [nvarchar](255) NOT NULL,
	[sodienthoai_khachhang] [nvarchar](255) NOT NULL,
	[ma_taikhoan] [varchar](255) NULL,
	[ma_ban] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hoadon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Trigger [tr_DelHoadon]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tr_DelHoadon]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[tr_DelHoadon]
on [dbo].[Hoadon] after update
as 
  begin
     delete Hoadon where tinhtrang = 1
  end
'
GO
/****** Object:  Table [dbo].[Chitiethoadon]    Script Date: 07/13/2019 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Chitiethoadon](
	[ma_cthd] [varchar](255) NOT NULL,
	[ma_sanpham] [varchar](10) NULL,
	[soluong] [int] NOT NULL,
	[ma_hoadon] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_cthd] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Taikhoan_Quyentruycap]    Script Date: 07/13/2019 12:12:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Taikhoan_Quyentruycap]') AND parent_object_id = OBJECT_ID(N'[dbo].[Taikhoan]'))
ALTER TABLE [dbo].[Taikhoan]  WITH CHECK ADD  CONSTRAINT [FK_Taikhoan_Quyentruycap] FOREIGN KEY([ma_quyen])
REFERENCES [dbo].[Quyentruycap] ([ma_quyen])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Taikhoan_Quyentruycap]') AND parent_object_id = OBJECT_ID(N'[dbo].[Taikhoan]'))
ALTER TABLE [dbo].[Taikhoan] CHECK CONSTRAINT [FK_Taikhoan_Quyentruycap]
GO
/****** Object:  ForeignKey [fk_Sanpham_Danhmuc]    Script Date: 07/13/2019 12:12:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Sanpham_Danhmuc]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sanpham]'))
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [fk_Sanpham_Danhmuc] FOREIGN KEY([ma_danhmuc])
REFERENCES [dbo].[Danhmuc] ([ma_danhmuc])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Sanpham_Danhmuc]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sanpham]'))
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [fk_Sanpham_Danhmuc]
GO
/****** Object:  ForeignKey [fk_Hoadon_Ban]    Script Date: 07/13/2019 12:12:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Hoadon_Ban]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [fk_Hoadon_Ban] FOREIGN KEY([ma_ban])
REFERENCES [dbo].[Ban] ([ma_ban])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Hoadon_Ban]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [fk_Hoadon_Ban]
GO
/****** Object:  ForeignKey [fk_Taikhoan_matk]    Script Date: 07/13/2019 12:12:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Taikhoan_matk]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [fk_Taikhoan_matk] FOREIGN KEY([ma_taikhoan])
REFERENCES [dbo].[Taikhoan] ([ma_taikhoan])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Taikhoan_matk]') AND parent_object_id = OBJECT_ID(N'[dbo].[Hoadon]'))
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [fk_Taikhoan_matk]
GO
/****** Object:  ForeignKey [fk_Chitiethoadon_Hoadon]    Script Date: 07/13/2019 12:12:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Hoadon]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon]  WITH CHECK ADD  CONSTRAINT [fk_Chitiethoadon_Hoadon] FOREIGN KEY([ma_hoadon])
REFERENCES [dbo].[Hoadon] ([ma_hoadon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Hoadon]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon] CHECK CONSTRAINT [fk_Chitiethoadon_Hoadon]
GO
/****** Object:  ForeignKey [fk_Chitiethoadon_Sanpham]    Script Date: 07/13/2019 12:12:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Sanpham]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon]  WITH CHECK ADD  CONSTRAINT [fk_Chitiethoadon_Sanpham] FOREIGN KEY([ma_sanpham])
REFERENCES [dbo].[Sanpham] ([ma_sanpham])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Chitiethoadon_Sanpham]') AND parent_object_id = OBJECT_ID(N'[dbo].[Chitiethoadon]'))
ALTER TABLE [dbo].[Chitiethoadon] CHECK CONSTRAINT [fk_Chitiethoadon_Sanpham]
GO
