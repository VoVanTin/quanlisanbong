USE [QLSB]
GO
/****** Object:  Table [dbo].[CHITIETHD]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHD](
	[MaHD] [int] NOT NULL,
	[MaDV] [int] NOT NULL,
	[Soluong] [int] NULL,
	[TongTienDV] [real] NULL,
 CONSTRAINT [PK_CHITIETHD] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DATSAN]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DATSAN](
	[MaDatSan] [int] IDENTITY(1,1) NOT NULL,
	[NgayApDung] [date] NULL,
	[GioVao] [varchar](10) NULL,
	[GioRa] [varchar](10) NULL,
	[sogio] [float] NULL,
	[MaSan] [int] NULL,
	[MaKH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDatSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICHVU](
	[MaDV] [int] IDENTITY(1,1) NOT NULL,
	[TenDV] [nvarchar](50) NULL,
	[Loai] [nvarchar](30) NULL,
	[Gia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[TongTien] [real] NULL,
	[NgayXuatHD] [nvarchar](50) NULL,
	[MaNhanSan] [int] NULL,
	[Username] [varchar](15) NULL,
	[TrangThai] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Sdt] [char](10) NULL,
	[Gioitinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANSAN]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANSAN](
	[MaNhanSan] [int] IDENTITY(1,1) NOT NULL,
	[NgayApDung] [date] NULL,
	[GioVao] [varchar](10) NULL,
	[GioRa] [varchar](10) NULL,
	[sogio] [float] NULL,
	[MaSan] [int] NULL,
	[MaKH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SANBONG]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANBONG](
	[MaSan] [int] IDENTITY(1,1) NOT NULL,
	[LoaiSan] [nvarchar](30) NULL,
	[Gia] [int] NULL,
	[TrangThai] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[Username] [varchar](15) NOT NULL,
	[Pass] [varchar](20) NULL,
	[HoTen] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
	[NgaySinh] [date] NULL,
	[Gioitinh] [nvarchar](10) NULL,
	[Quyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongKe]    Script Date: 16/12/2021 2:30:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongKe](
	[thang] [int] NOT NULL,
	[doanhthu] [int] NULL,
	[nam] [int] NOT NULL,
 CONSTRAINT [PK_ThongKe] PRIMARY KEY CLUSTERED 
(
	[thang] ASC,
	[nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DATSAN] ON 

INSERT [dbo].[DATSAN] ([MaDatSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (1, CAST(N'2021-11-20' AS Date), N'5', N'6', 1, 1, 2)
INSERT [dbo].[DATSAN] ([MaDatSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (2, CAST(N'2021-10-27' AS Date), N'8', N'9', 1, 3, 3)
INSERT [dbo].[DATSAN] ([MaDatSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (3, CAST(N'2021-09-22' AS Date), N'4', N'6', 2, 4, 4)
INSERT [dbo].[DATSAN] ([MaDatSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (4, CAST(N'2021-11-26' AS Date), N'3', N'4', 1, 2, 6)
INSERT [dbo].[DATSAN] ([MaDatSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (5, CAST(N'2021-10-19' AS Date), N'8', N'10', 2, 5, 5)
SET IDENTITY_INSERT [dbo].[DATSAN] OFF
SET IDENTITY_INSERT [dbo].[DICHVU] ON 

INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (1, N'Revive', N'Thức Uống', 10000)
INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (2, N'Nước Suối', N'Thức Uống', 6000)
INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (3, N'Redbull', N'Thức Uống', 20000)
INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (4, N'Coca Coca', N'Thức Uống', 10000)
INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (5, N'Mì Tôm', N'Thức Ăn', 15000)
INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (6, N'Bánh Mì', N'Thức Ăn', 15000)
INSERT [dbo].[DICHVU] ([MaDV], [TenDV], [Loai], [Gia]) VALUES (7, N'Bánh Tráng', N'Thức Ăn', 10000)
SET IDENTITY_INSERT [dbo].[DICHVU] OFF
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([MaHD], [MaKH], [TongTien], [NgayXuatHD], [MaNhanSan], [Username], [TrangThai]) VALUES (1, 2, 100000, N'', 6, N'binhphuong', N'Chưa Thanh Toán')
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (1, N'Lê Văn Can', N'0123456781', N'Nam', CAST(N'2000-12-21' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (2, N'Nguyễn Thị Thuỷ', N'0123456782', N'Nữ', CAST(N'2001-03-26' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (3, N'Trần Minh', N'0123456783', N'Nam', CAST(N'1998-10-09' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (4, N'Lê Thị An', N'0123456784', N'Nữ', CAST(N'1996-11-25' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (5, N'Nguyễn Long Bình', N'0123456785', N'Nam', CAST(N'2003-03-07' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (6, N'Bùi Xuân Anh', N'0123456786', N'Nam', CAST(N'1999-04-19' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (7, N'Lý Công', N'0123456787', N'Nam', CAST(N'2001-05-25' AS Date))
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Gioitinh], [NgaySinh]) VALUES (8, N'Trần Thị Mộng', N'0354687598', N'Nữ', CAST(N'2002-03-15' AS Date))
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[NHANSAN] ON 

INSERT [dbo].[NHANSAN] ([MaNhanSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (1, CAST(N'2021-11-20' AS Date), N'5', N'6', 1, 1, 2)
INSERT [dbo].[NHANSAN] ([MaNhanSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (2, CAST(N'2021-10-27' AS Date), N'8', N'9', 1, 3, 3)
INSERT [dbo].[NHANSAN] ([MaNhanSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (3, CAST(N'2021-09-22' AS Date), N'4', N'6', 2, 4, 4)
INSERT [dbo].[NHANSAN] ([MaNhanSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (4, CAST(N'2021-11-26' AS Date), N'3', N'4', 1, 2, 6)
INSERT [dbo].[NHANSAN] ([MaNhanSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (5, CAST(N'2021-10-19' AS Date), N'8', N'10', 2, 5, 5)
INSERT [dbo].[NHANSAN] ([MaNhanSan], [NgayApDung], [GioVao], [GioRa], [sogio], [MaSan], [MaKH]) VALUES (6, CAST(N'2021-11-20' AS Date), N'5', N'6', 1, 1, 2)
SET IDENTITY_INSERT [dbo].[NHANSAN] OFF
SET IDENTITY_INSERT [dbo].[SANBONG] ON 

INSERT [dbo].[SANBONG] ([MaSan], [LoaiSan], [Gia], [TrangThai]) VALUES (1, N'Sân 1', 100000, N'Có Người')
INSERT [dbo].[SANBONG] ([MaSan], [LoaiSan], [Gia], [TrangThai]) VALUES (2, N'Sân 2', 150000, N'Trống')
INSERT [dbo].[SANBONG] ([MaSan], [LoaiSan], [Gia], [TrangThai]) VALUES (3, N'Sân 3', 200000, N'Trống')
INSERT [dbo].[SANBONG] ([MaSan], [LoaiSan], [Gia], [TrangThai]) VALUES (4, N'Sân Mini', 250000, N'Trống')
INSERT [dbo].[SANBONG] ([MaSan], [LoaiSan], [Gia], [TrangThai]) VALUES (5, N'Sân Lớn', 300000, N'Trống')
INSERT [dbo].[SANBONG] ([MaSan], [LoaiSan], [Gia], [TrangThai]) VALUES (6, N'Sân Thi Đấu', 400000, N'Trống')
SET IDENTITY_INSERT [dbo].[SANBONG] OFF
INSERT [dbo].[TAIKHOAN] ([Username], [Pass], [HoTen], [SDT], [NgaySinh], [Gioitinh], [Quyen]) VALUES (N'binhphuong', N'123', N'Trần Trọng Bình Phương', N'0372645002', CAST(N'2001-06-25' AS Date), N'Nam', 1)
INSERT [dbo].[TAIKHOAN] ([Username], [Pass], [HoTen], [SDT], [NgaySinh], [Gioitinh], [Quyen]) VALUES (N'nhanvien', N'123', N'Nhân viên 1', N'0856542478', CAST(N'2001-05-19' AS Date), N'Nữ', 2)
INSERT [dbo].[TAIKHOAN] ([Username], [Pass], [HoTen], [SDT], [NgaySinh], [Gioitinh], [Quyen]) VALUES (N'vantin', N'123', N'Võ Văn Tin', N'0964848973', CAST(N'2001-12-21' AS Date), N'Nam', 1)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (1, 5000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (1, 6000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (2, 3000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (2, 3000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (3, 7000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (3, 7000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (4, 2400000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (4, 2400000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (5, 4300000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (5, 4300000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (6, 10000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (6, 10000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (7, 7500000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (7, 7500000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (8, 2000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (8, 2000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (9, 4500000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (9, 4500000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (10, 6000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (10, 10000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (11, 7000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (11, 7000000, 2021)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (12, 2000000, 2020)
INSERT [dbo].[ThongKe] ([thang], [doanhthu], [nam]) VALUES (12, 2000000, 2021)
ALTER TABLE [dbo].[CHITIETHD]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHD_DICHVU] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DICHVU] ([MaDV])
GO
ALTER TABLE [dbo].[CHITIETHD] CHECK CONSTRAINT [FK_CHITIETHD_DICHVU]
GO
ALTER TABLE [dbo].[CHITIETHD]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHD_HOADON] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HOADON] ([MaHD])
GO
ALTER TABLE [dbo].[CHITIETHD] CHECK CONSTRAINT [FK_CHITIETHD_HOADON]
GO
ALTER TABLE [dbo].[DATSAN]  WITH CHECK ADD  CONSTRAINT [FK_KH_DS] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DATSAN] CHECK CONSTRAINT [FK_KH_DS]
GO
ALTER TABLE [dbo].[DATSAN]  WITH CHECK ADD  CONSTRAINT [FK_SB_DS] FOREIGN KEY([MaSan])
REFERENCES [dbo].[SANBONG] ([MaSan])
GO
ALTER TABLE [dbo].[DATSAN] CHECK CONSTRAINT [FK_SB_DS]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_KH_HD] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_KH_HD]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_NS_HD] FOREIGN KEY([MaNhanSan])
REFERENCES [dbo].[NHANSAN] ([MaNhanSan])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_NS_HD]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_TK_HD] FOREIGN KEY([Username])
REFERENCES [dbo].[TAIKHOAN] ([Username])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_TK_HD]
GO
ALTER TABLE [dbo].[NHANSAN]  WITH CHECK ADD  CONSTRAINT [FK_KH_NS] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[NHANSAN] CHECK CONSTRAINT [FK_KH_NS]
GO
ALTER TABLE [dbo].[NHANSAN]  WITH CHECK ADD  CONSTRAINT [FK_SB_NS] FOREIGN KEY([MaSan])
REFERENCES [dbo].[SANBONG] ([MaSan])
GO
ALTER TABLE [dbo].[NHANSAN] CHECK CONSTRAINT [FK_SB_NS]
GO
