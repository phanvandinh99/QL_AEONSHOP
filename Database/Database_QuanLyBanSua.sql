CREATE DATABASE DATA_EAONSHOP
GO
USE DATA_EAONSHOP
GO
CREATE TABLE CongViec
(
	MaCongViec varchar(10) primary key,
	TenCongViec nvarchar(100) not null,
	MoTa nvarchar(255) null,
)
go
insert into CongViec (MaCongViec, TenCongViec, MoTa) values ('CV0001', N'Học Sinh, Sinh Viên', N'Độ tuổi <= 18 đang còn đi học');
insert into CongViec (MaCongViec, TenCongViec, MoTa) values ('CV0002', N'Lao Động Phổ Thông', N'Lao động chân tay, bán thời gian');
insert into CongViec (MaCongViec, TenCongViec, MoTa) values ('CV0003', N'Nhân Viên Văn Phòng', N'Lao động phổ thông bằng trí óc');
insert into CongViec (MaCongViec, TenCongViec, MoTa) values ('CV0004', N'Khác', N'Không thuộc phạm vi đối tượng trên');
insert into CongViec (MaCongViec, TenCongViec, MoTa) values ('CV0005', N'Thất Nghiệp', N'Thất nghiệp khoặc không có khả năng lao động');
go
CREATE TABLE ThuNhap
(
	MaThuNhap varchar(10) primary key,
	TenThuNhap nvarchar(100) not null,
	SoTien varchar(100) null,
)
go
insert into ThuNhap (MaThuNhap, TenThuNhap, SoTien) values ('TN0001', N'Dưới 6.000.000', '0-6000000');
insert into ThuNhap (MaThuNhap, TenThuNhap, SoTien) values ('TN0002', N'Từ 6.000.000 đến dưới 13.000.000', '6000000-13000000');
insert into ThuNhap (MaThuNhap, TenThuNhap, SoTien) values ('TN0003', N'Từ 13.000.000 đến dưới 50.000.000', '13000000-50000000');
insert into ThuNhap (MaThuNhap, TenThuNhap, SoTien) values ('TN0004', N'Trên 50.000.000', '50.000.000-0');
insert into ThuNhap (MaThuNhap, TenThuNhap, SoTien) values ('TN0005', N'Không có thu nhập(/Không thu thập được)', '0-0');
go
CREATE TABLE TinhTrangSucKhoe
(
	MaTinhTrangSK varchar(10) primary key,
	TenTinhTrang nvarchar(100) not null,
	MoTa nvarchar(255) null,
)
go
insert into TinhTrangSucKhoe (MaTinhTrangSK, TenTinhTrang, MoTa) values ('SK0001', N'Bình Thường', N'Sức khỏe ổn định');
insert into TinhTrangSucKhoe (MaTinhTrangSK, TenTinhTrang, MoTa) values ('SK0002', N'Người Già', N'Sức khỏe không ổn định');
insert into TinhTrangSucKhoe (MaTinhTrangSK, TenTinhTrang, MoTa) values ('SK0003', N'Bệnh Hiểm Nghèo', N'Sức khỏe không ổn định');
insert into TinhTrangSucKhoe (MaTinhTrangSK, TenTinhTrang, MoTa) values ('SK0004', N'Cân Đối', N'Người thuộc sức khỏe ổn định từ mọi mặt');
insert into TinhTrangSucKhoe (MaTinhTrangSK, TenTinhTrang, MoTa) values ('SK0005', N'Khác', N'Không thu thập được từ người dùng');
go
CREATE TABLE KhachHang
(
	SDT varchar(12) primary key,
	HoTen nvarchar(200) not null,
	NgaySinh Datetime null,
	GioiTinh nvarchar(50) null,
	Sothich nvarchar(max) null,
	MaCongViec varchar(10),
	MaThuNhap varchar(10),
	MaTinhTrangSK varchar(10),

	foreign key(MaCongViec) references CongViec(MaCongViec),
	foreign key(MaThuNhap) references ThuNhap(MaThuNhap),
	foreign key(MaTinhTrangSK) references TinhTrangSucKhoe(MaTinhTrangSK),
)
go
insert into KhachHang (SDT, HoTen, NgaySinh, GioiTinh, Sothich, MaCongViec, MaThuNhap, MaTinhTrangSK) 
values ('0971010281', N'Nhân Neil', '2/1/1995', N'Nam', N'Uống Sữa Vinamilk không đường', 'CV0001', 'TN0001', 'SK0001');
insert into KhachHang (SDT, HoTen, NgaySinh, GioiTinh, Sothich, MaCongViec, MaThuNhap, MaTinhTrangSK) 
values ('0395241568', N'Kiều Trang', '3/1/1994', N'Nữ', N'Uống Sữa Vinamilk có đường', 'CV0002', 'TN0002', 'SK0002');
insert into KhachHang (SDT, HoTen, NgaySinh, GioiTinh, Sothich, MaCongViec, MaThuNhap, MaTinhTrangSK) 
values ('0325456987', N'Quang Anh', '8/9/1997', N'Nam', N'Uống Sữa Đà Lạt không đường', 'CV0003', 'TN0003', 'SK0003');
insert into KhachHang (SDT, HoTen, NgaySinh, GioiTinh, Sothich, MaCongViec, MaThuNhap, MaTinhTrangSK) 
values ('0123542874', N'Xuân Vinh', '4/12/1980', N'Nam', N'Uống Sữa Đà Lạt có đường', 'CV0004', 'TN0004', 'SK0004');
insert into KhachHang (SDT, HoTen, NgaySinh, GioiTinh, Sothich, MaCongViec, MaThuNhap, MaTinhTrangSK) 
values ('0341251232', N'Thanh Thúy', '2/11/1955', N'Nữ', N'Uống Sữa Vinamilk không đường', 'CV0005', 'TN0005', 'SK0005');
go
CREATE TABLE Quyen
(
	MaQuyen int identity(1,1) primary key,
	TenQuyen nvarchar(100) not null,
	MoTa nvarchar(255) null,
)
go
insert into Quyen (TenQuyen, MoTa) values (N'Quền Admin', 'Người có quyền cao nhất hệ thống');
insert into Quyen (TenQuyen, MoTa) values (N'Quền Nhân Viên', 'Nhân viên quản trị hệ thống');
insert into Quyen (TenQuyen, MoTa) values (N'Quền Admin', 'Nhân viên kho, quản lý việc nhập/xuất kho');
go
CREATE TABLE NhanVien
(
	TaiKhoanNV varchar(50) primary key,
	MatKhau varchar(50) not null,
	HoTen nvarchar(255) not null,
	NgaySinh Datetime null,
	Email nvarchar(50) null,
	MaQuyen int,

	foreign key(MaQuyen) references Quyen(MaQuyen),
)
go
insert into NhanVien (TaiKhoanNV, MatKhau, HoTen, NgaySinh, Email, MaQuyen) values ('Admin', 'abc123', N'Admin', '01/05/2000', 'admin@gmail.com', 1);
insert into NhanVien (TaiKhoanNV, MatKhau, HoTen, NgaySinh, Email, MaQuyen) values ('Nhan', 'abc123', N'Nhân Neil', '01/04/2000', 'nhan@gmail.com', 1);
insert into NhanVien (TaiKhoanNV, MatKhau, HoTen, NgaySinh, Email, MaQuyen) values ('NhanVien', 'abc123', N'Nhân Viên', '01/06/2000', 'nhanvien@gmail.com', 2);
insert into NhanVien (TaiKhoanNV, MatKhau, HoTen, NgaySinh, Email, MaQuyen) values ('Kho', 'abc123', N'Quản Kho', '01/07/2000', 'kho@gmail.com', 3);
insert into NhanVien (TaiKhoanNV, MatKhau, HoTen, NgaySinh, Email, MaQuyen) values ('Admin2', 'abc123', N'Admin 2', '01/08/2000', 'admin2@gmail.com', 1);
go
CREATE TABLE HoaDon
(
	MaHoaDon varchar(10) primary key,
	NgayBan Datetime default(getdate()),
	TrangThai int default(0), -- 0: chưa thanh toán, 1: đã thanh toán
	TongTien float null,
	SDT varchar(12),
	TaiKhoanNV varchar(50),

	foreign key(SDT) references KhachHang(SDT),
	foreign key(TaiKhoanNV) references NhanVien(TaiKhoanNV),
)
go
insert into HoaDon (MaHoaDon, NgayBan, TrangThai, TongTien, SDT, TaiKhoanNV)
values ('HD0001', default, 1, 500000, '0971010281', 'Admin');
insert into HoaDon (MaHoaDon, NgayBan, TrangThai, TongTien, SDT, TaiKhoanNV)
values ('HD0002', default, 1, 700000, '0395241568', 'Admin');
insert into HoaDon (MaHoaDon, NgayBan, TrangThai, TongTien, SDT, TaiKhoanNV)
values ('HD0003', default, 1, 400000, '0325456987', 'Admin');
insert into HoaDon (MaHoaDon, NgayBan, TrangThai, TongTien, SDT, TaiKhoanNV)
values ('HD0004', default, 1, 300000, '0123542874', 'Admin');
insert into HoaDon (MaHoaDon, NgayBan, TrangThai, TongTien, SDT, TaiKhoanNV)
values ('HD0005', default, 1, 200000, '0341251232', 'Admin');
go
CREATE TABLE LoaiSanPham
(
	MaLoaiSanPham varchar(10) primary key,
	TenLoaiSanPham nvarchar(255) not null,
	SoLuong int null,
)
go
insert into LoaiSanPham (MaLoaiSanPham, TenLoaiSanPham, SoLuong) values ('LSP001', N'Sữa Cho Mẹ Bầu Và Sau Sinh', 10);
insert into LoaiSanPham (MaLoaiSanPham, TenLoaiSanPham, SoLuong) values ('LSP002', N'Sữa Cho Bé 0-24 Tháng', 10);
insert into LoaiSanPham (MaLoaiSanPham, TenLoaiSanPham, SoLuong) values ('LSP003', N'Sữa Cho Bé Trên 24 Tháng', 10);
insert into LoaiSanPham (MaLoaiSanPham, TenLoaiSanPham, SoLuong) values ('LSP004', N'Sữa Cho Mọi Lứa Tuổi', 10);
insert into LoaiSanPham (MaLoaiSanPham, TenLoaiSanPham, SoLuong) values ('LSP005', N'Sữa Cho Người Ăn Kiêng', 10);
go
CREATE TABLE SanPham
(
	MaSanPham varchar(10) primary key,
	TenSanPham nvarchar(255) not null,
	DaBan int null,
	Anh nvarchar(max) default(N'AnhSua.jpg'),
	MoTa nvarchar(max) null,
	MaLoaiSanPham varchar(10),

	foreign key(MaLoaiSanPham) references LoaiSanPham(MaLoaiSanPham),
)
go
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0001', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0002', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0003', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0004', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0005', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0006', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0007', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0008', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP0009', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
insert into SanPham (MaSanPham, TenSanPham, DaBan, Anh, MoTa, MaLoaiSanPham)
values ('SP00010', N'Sữa Bầu Enfamama A+ Hương Socola Hộp 400g', 10, default, N'Lưu ý: Bao bì và màu sản phẩm có thể thay đổi giữa các đợt nhập hàng', 'LSP001');
go
CREATE TABLE ChiTietSanPham
(
	NgaySanXuat datetime,
	HanSuDung datetime,
	MaSanPham varchar(10),
	primary key (NgaySanXuat, HanSuDung, MaSanPham),
	NgaySuDungConLai int default(0),
	SoLuongHienCon int default(0),
	DonGiaNhap float not null,
	DonGiaBan float not null,

	foreign key(MaSanPham) references SanPham(MaSanPham),
)
go
insert into ChiTietSanPham (NgaySanXuat, HanSuDung, MaSanPham, NgaySuDungConLai, SoLuongHienCon, DonGiaNhap, DonGiaBan)
values ('2022/02/04', '2022/03/04', 'SP0001', 15, 20, 150000, 160000);
insert into ChiTietSanPham (NgaySanXuat, HanSuDung, MaSanPham, NgaySuDungConLai, SoLuongHienCon, DonGiaNhap, DonGiaBan)
values ('2022/02/04', '2022/03/04', 'SP0002', 15, 20, 150000, 160000);
insert into ChiTietSanPham (NgaySanXuat, HanSuDung, MaSanPham, NgaySuDungConLai, SoLuongHienCon, DonGiaNhap, DonGiaBan)
values ('2022/02/04', '2022/03/04', 'SP0003', 15, 20, 150000, 160000);
go
CREATE TABLE ChiTietHoaDon
(
	MaHoaDon varchar(10),
	MaSanPham varchar(10),
	primary key (MaHoaDon, MaSanPham),
	SoLuongMua int default(1),
	ThanhTien float null,

	foreign key(MaHoaDon) references HoaDon(MaHoaDon),
	foreign key(MaSanPham) references SanPham(MaSanPham),
)
go
insert into ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuongMua, ThanhTien) values ('HD0001', 'SP0001', 1, 200000);
insert into ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuongMua, ThanhTien) values ('HD0002', 'SP0002', 1, 300000);
insert into ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuongMua, ThanhTien) values ('HD0003', 'SP0003', 1, 400000);
insert into ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuongMua, ThanhTien) values ('HD0004', 'SP0004', 1, 500000);
insert into ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuongMua, ThanhTien) values ('HD0005', 'SP0005', 1, 600000);
go
CREATE TABLE NhapKho
(
	MaNhapKho varchar(10) primary key,
	NgayNhapKho datetime default(getdate()),
	TongTien float,
	TaiKhoanNV varchar(50),

	foreign key(TaiKhoanNV) references Nhanvien(TaiKhoanNV),
)
go
insert into NhapKho (MaNhapKho, NgayNhapKho, TongTien, TaiKhoanNV) values ('NK0001', default, 200000, 'Admin');
insert into NhapKho (MaNhapKho, NgayNhapKho, TongTien, TaiKhoanNV) values ('NK0002', default, 300000, 'Admin');
insert into NhapKho (MaNhapKho, NgayNhapKho, TongTien, TaiKhoanNV) values ('NK0003', default, 400000, 'Admin');
insert into NhapKho (MaNhapKho, NgayNhapKho, TongTien, TaiKhoanNV) values ('NK0004', default, 500000, 'Admin');
insert into NhapKho (MaNhapKho, NgayNhapKho, TongTien, TaiKhoanNV) values ('NK0005', default, 600000, 'Admin');
go
CREATE TABLE ChiTietNhapKho
(
	MaHoaDon varchar(10),
	MaSanPham varchar(10),
	primary key (MaHoaDon, MaSanPham),
	SoLuongNhap int default(1),
	DonGiaNhap float null,
	ThanhTien float null,

	foreign key(MaHoaDon) references HoaDon(MaHoaDon),
	foreign key(MaSanPham) references SanPham(MaSanPham),
)
go
insert into ChiTietNhapKho (MaHoaDon, MaSanPham, SoLuongNhap, DonGiaNhap, ThanhTien) values ('HD0001', 'SP0001', 10, 200000, 2000000);
insert into ChiTietNhapKho (MaHoaDon, MaSanPham, SoLuongNhap, DonGiaNhap, ThanhTien) values ('HD0002', 'SP0002', 10, 300000, 3000000);
insert into ChiTietNhapKho (MaHoaDon, MaSanPham, SoLuongNhap, DonGiaNhap, ThanhTien) values ('HD0003', 'SP0003', 10, 400000, 4000000);
insert into ChiTietNhapKho (MaHoaDon, MaSanPham, SoLuongNhap, DonGiaNhap, ThanhTien) values ('HD0004', 'SP0004', 10, 500000, 5000000);
insert into ChiTietNhapKho (MaHoaDon, MaSanPham, SoLuongNhap, DonGiaNhap, ThanhTien) values ('HD0005', 'SP0005', 10, 600000, 6000000);
go


-- =================================================== STORE PROCEDURE =================================================== --

-- ========== ĐĂNG NHẬP HỆ THỐNG ========== --





