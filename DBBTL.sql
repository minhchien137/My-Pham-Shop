
create database QLBanMyPham

create table tblNhanVien(
 iMaNV int primary key,
 sHoTen nvarchar(30),
 dNgaySinh datetime,
 sGioiTinh nvarchar(3),
 fPhuCap float,
 fluongCB float,
 sDienThoai nvarchar(15),
)
insert into tblNhanVien(iMaNV, sHoTen, dNgaySinh, sGioiTinh, fPhuCap, fLuongCB, sDienThoai)
values	(111, N'Hoàng Thùy'	, '12/1/1999', N'nữ' , 20000, 500000, '0357559469'),
		(122, N'Lê Dũng'	, '1/12/1980', N'nam', 50000, 700000, '0457449469'),
		(133, N'Hương Lê'	, '3/28/1995', N'nữ' , 30000, 500000, '0557339469'),
		(144, N'Quang Anh'	, '5/11/2000', N'nam', 50000, 800000, '0657229469'),
		(155, N'Thành Đạt'	, '8/8/1999' , N'nam', 50000, 500000, '0757119469')

create table tblKhachHang(
 iMaKH int primary key,
 sHoTen nvarchar(30),
 sDienThoai nvarchar(15),
 sDiaChi nvarchar(30),
)
insert into tblKhachHang(iMaKH, sHoTen, sDienThoai, sDiaChi)
values	(211, N'Hà Thương' , '0963101512', N'Hà Nội'		),
		(222, N'Thu Trang' , '0863101513', N'Hồ Chí Minh'	),
		(233, N'Long Thành', '0763101514', N'Phú Quốc'		),
		(244, N'Huy Hoàng' , '0663101515', N'Hội An'		),
		(255, N'Như Phương', '0563101516', N'Đà Nẵng'		)


create table tblNhaCC(
 iMaNCC int primary key,
 sTenNCC nvarchar(30),
 sDiaChi nvarchar(30),
 sSDT nvarchar(15)
)
insert into tblNhaCC(iMaNCC, sTenNCC, sDiaChi, sSDT)
values	(011, N'Ohui'		, N'Hàn Quốc', '0965428122'),
		(022, N'Dior'		, N'Pháp'	 , '0865428232'),
		(033, N'Maybelline'	, N'Mỹ'		 , '0765428342'),
		(044, N'Loreal'		, N'Nga'	 , '0665428452'),
		(055, N'Chanel'		, N'Anh Quốc', '0565428562')


create table tblSanPham(
sMaSP nvarchar(30) primary key,
sTenSP nvarchar(30),
iMaNCC int  not null references tblNhaCC(iMaNCC),
iSoLuong int,
fGiaHang float,
fTrongLuong float,
sMauSac nvarchar(30),
sHangSanPham nvarchar(30),
dNgayHetHan datetime
)
alter table tblSanPham
alter column dNgayHetHan datetime
    

insert into tblSanPham(sMaSP, sTenSP, iMaNCC, iSoLuong, fGiaHang)
values	('h11', N'mặt nạ lột'	 , 011, 100, 50000),
		('h22', N'mặt nạ rửa'	 , 011, 150, 100000),
		('h33', N'mặt nạ ngủ'	 , 011, 100, 150000),
		('h44', N'mặt nạ sủi bọt', 011, 150, 70000),
		('h55', N'mặt nạ đất sét', 011, 100, 200000)

create table tblHoaDonBan(
iMaHD int primary key,
iMaNV int not null  references tblNhanVien(iMaNV),
iMaKH int not null  references tblKhachHang(iMaKH),
dNgayDat datetime,
dNgayGiao datetime,
sDiaChiGiao nvarchar(30)
)
insert into tblHoaDonBan (iMaHD, iMaNV, iMaKH, dNgayDat, dNgayGiao, sDiaChiGiao)
VALUES	(311, 111, 211, '1/1/2021', '1/12/2021', N'Thanh Xuân - Hà Nội'),
		(322, 122, 222, '2/1/2021', '2/13/2021', N'Quận 9 - HCM'),
		(333, 133, 233, '3/1/2021', '3/14/2021', N'Đà Nẵng - Quảng Nam'),
		(344, 144, 244, '4/1/2021', '4/15/2021', N'Phú Quốc - Kiên Giang'),
		(355, 155, 255, '5/1/2021', '5/16/2021', N'Cầu Giấy - Hà Nội')

create table tblHoaDonNhap(
iMaHD int primary key,
iMaNV int not null  references tblNhanVien(iMaNV),
dNgayNhapSP datetime
)

alter table tblHoaDonNhap
add sTrangThai nvarchar(50)

alter column dNgayHetHan datetime

insert into tblHoaDonNhap (iMaHD, iMaNV, dNgayNhapSP)
VALUES	(411, 111, '6/11/2020'),
		(422, 122, '7/11/2020'),
		(433, 133, '8/11/2020'),
		(444, 144, '9/11/2020'),
		(455, 155, '10/11/2020')

create table tblCT_HDBan(
iMaHD int  references tblHoaDonBan(iMaHD),
sMaSP nvarchar(30) not NULL references tblSanPham(sMaSP),
fGiaBan float,
iSoluong int,
constraint PK_HDB primary key(iMaHD,sMaSP)
)
insert into tblCT_HDBan (iMaHD, sMaSP,fGiaBan,iSoluong)
values	(311, 'h11', 70000, 200),
		(322, 'h11', 70000, 200),
		(333, 'h22', 150000, 200),
		(344, 'h33', 170000, 200),
		(355, 'h44', 100000, 200)


create table tblCT_HDNhap(
iMaHD int references tblHoaDonNhap(iMaHD),
sMaSP nvarchar(30) not NULL references tblSanPham(sMaSP),
fGiaNhap float,
iSoluong int,
constraint  PK_HDN primary key(iMaHD,sMaSP)
)
insert into tblCT_HDNhap (iMaHD, sMaSP, fGiaNhap, iSoluong)
values	(411, 'h11', 30000, 200),
		(422, 'h11', 30000, 200),
		(433, 'h22', 50000, 200),
		(444, 'h33', 100000, 200),
		(455, 'h44', 50000, 200)
select*from tblNhanVien
select*from tblHoaDonBan

-------Thêm nhân viên----------
create proc ThemNhanVien
(@MaNV int, @HoTen nvarchar(30),  @NgaySinh  DateTime,
 @GioiTinh nvarchar(3),@PhuCap float,@luongCB float ,@DienThoai nvarchar(12))
 as
 insert into tblNhanVien(iMaNV, sHoTen, dNgaySinh, sGioiTinh, fPhuCap, fLuongCB, sDienThoai)
 values	(@MaNV, @HoTen, @NgaySinh, @GioiTinh , @PhuCap, @luongCB, @DienThoai)

 ---------xóa nhân viên ---------
 create proc XoaNhanVien
(@MaNV int)
 as
 delete from tblNhanVien
 where iMaNV=@MaNV

 ------Thêm hoá đơn bán --------
 create proc ThemHoaDonBan
(@MaHD int, @MaNV int,@MaKH int,@NgayDat datetime,@NgayGiao datetime,@DiaChiGiao nvarchar(30))
 as
 insert into tblHoaDonBan(iMaHD, iMaNV ,iMaKH,dNgayDat,dNgayGiao,sDiaChiGiao)
 values	(@MaHD, @MaNV ,@MaKH ,@NgayDat ,@NgayGiao,@DiaChiGiao )
  
  -------sửa nhân viên-----
 create proc suaNhanVien
 (@MaNV int, @HoTen nvarchar(30))
 as
 update tblNhanVien
 set sHoTen=@HoTen
 where iMaNV=@MaNV

 ------tìm nhân viên--------
 create proc timNhanVien_HDB
 (@MaHD int)
 as
 select tblNhanVien.iMaNV, sHoTen
 from tblNhanVien, tblHoaDonBan
 where tblNhanVien.iMaNV=tblHoaDonBan.iMaNV
 and iMaHD =@MaHD
 exec timNhanVien_HDB '311'

create view NhanVien_HDB
 as
 select tblNhanVien.iMaNV, sHoTen, iMaHD
 from tblNhanVien, tblHoaDonBan
 where tblNhanVien.iMaNV=tblHoaDonBan.iMaNV

 select * from NhanVien_HDB
 select *from tblHoaDonBan
 select*from tblNhanVien

 --------thêm khách hàng----------
 create proc ThemKH
 (@maKH int, @HoTen Nvarchar(30),@DiaChi NvarChar(30),@DT NvarChar(15))
 as
 insert into tblKhachHang
 values (@MaKH, @HoTen,@DT, @DiaCHi)

 ---------xóa khách hàng---------
 create proc XoaKH
 (@maKH int)
 as
 delete from tblKhachHang
 where iMaKH=@maKH

 exec XoaKH @maKH='9'

 ----------sửa kH--------
 create proc suaKhachHang
 (@maKH int, @HoTen Nvarchar(30),@DiaChi NvarChar(30),@DT NvarChar(15))
 as
 update tblKhachHang
 set sHoten=@HoTen,
 sDiaChi=@DiaChi,
 sDienThoai=@DT
 where iMaKH=@maKH

 -------------tìm KH--------------
 create proc timKH_HD
 (@maHD int)
 as
 select*from tblKhachHang,tblHoaDonBan
 where tblKhachHang.iMaKH= tblHoaDonBan.iMaKH
 and iMaHD=@maHD


 create view KH_HD
 as 
 select tblKhachHang.iMaKH, sHoten,sDiaChi,sDienThoai,iMaHD from  tblKhachHang,tblHoaDonBan
 where tblKhachHang.iMaKH= tblHoaDonBan.iMaKH
 
 
create view HD
as
select 
iMaHD ,tblKhachHang.sHoTen as[HotenKH],
tblHoaDonBan.iMaKH,
tblNhanVien.sHoTen,tblHoaDonBan.iMaNV ,dNgayDat,
dNgayGiao  ,sDiaChiGiao,sTrangThai
from tblHoaDonBan, tblKhachHang, tblNhanVien
where tblKhachHang.iMaKH=tblHoaDonBan.iMaKH and tblHoaDonBan.iMaNV=tblNhanVien.iMaNV

select*from tblHoaDonBan

---------Thêm HDB--------
create proc ThemHDB
(@iMaHD int,
@MaNV int,
@MaKH int ,
@NgayDat datetime,
@NgayGiao datetime,
@DiaChiGiao nvarchar(30),
@TrangThai nvarchar(30))
as
insert into tblHoaDonban(
iMaHD,
iMaNV,
iMaKH,
dNgayDat,
dNgayGiao,
sDiaChiGiao,
sTrangThai)
values (@iMaHD ,@MaNV,@MaKH  ,
@NgayDat , @NgayGiao ,@DiaChiGiao,@TrangThai)

select *from HD where sTrangThai like N'%Đã thanh toán%'
select * from tblCT_HDBan

----Xoa HDB----------
create proc XoaHDB
(@MaHD int)
as
begin
	IF NOT EXISTS (SELECT * FROM dbo.tblHoaDonBan WHERE iMaHD= @MaHD)
		BEGIN
			PRINT N'Khách hàng NÀY KHÔNG TỒN TẠI'
			RETURN -1
		END
		delete from tblHoaDonBan
		where iMaHD=@MaHD
		PRINT N'Xoá thành công'
END

drop proc XoaHDB


create proc SuaHDB
(@MaHD int,
@MaNV int,
@MaKH int ,
@NgayDat datetime,
@NgayGiao datetime,
@DiaChiGiao nvarchar(30),
@TrangThai nvarchar(30))
as
update tblHoaDonBan
set iMaNV=@MaNV ,
	iMaKH=@MaKH ,
	dNgayDat=@NgayDat ,
	dNgayGiao=@NgayGiao,
	sDiaChiGiao=@DiaChiGiao,
	sTrangThai=@TrangThai 
where iMaHD=@MaHD

alter table tblHoaDonBan
ADD iTongTien float
UPDATE dbo.tblHoaDonBan
SET iTongTien = (SELECT sum (fGiaBan*iSoLuong) FROM tblCT_HDBan WHERE tblCT_HDBan.iMaHD=tblHoaDonBan.iMaHD)
FROM tblHoaDonBan,tblCT_HDBan
WHERE tblCT_HDBan.iMaHD=tblHoaDonBan.iMaHD
SELECT * FROM dbo.tblHoaDonBan



CREATE TRIGGER capnhapTongTien
ON tblCT_HDBan
AFTER INSERT, DELETE 
AS 
BEGIN
	DECLARE @maHDxoa NVARCHAR(30), @maHDthem NVARCHAR(30),
	@giaBanthem float,@giaBanxoa float, @soluongxoa int,@soluongThem int;
	SELECT @maHDthem=iMaHD,@giaBanthem=fGiaBan,@soluongThem=iSoLuong FROM inserted
	SELECT @maHDxoa=iMaHD ,@giaBanxoa=fGiaBan,@soluongxoa=iSoLuong FROM deleted

	UPDATE tblHoaDonBan
	SET fTongTien= fTongTien +(@giaBanthem*@soluongThem)
	FROM tblCT_HDBan
	WHERE tblCT_HDBan.iMaHD=@maHDthem and tblCT_HDBan.iMaHD=tblHoaDonBan.iMaHD

	UPDATE tblHoaDonBan
	SET fTongTien= fTongTien +(@giaBanxoa*@soluongxoa)
	FROM tblCT_HDBan
	WHERE  tblCT_HDBan.iMaHD=@maHDxoa and tblCT_HDBan.iMaHD=tblHoaDonBan.iMaHD
END 


create view top3HDB
as
select top(3) fTongTien from tblHoaDonBan
order by fTongTien desc
select fTongTien from tblHoaDonBan

alter table tblCT_HDBan
add fthanhtien float

update tblCT_HDBan
set fthanhtien=isoluong*fgiaban

select * from tblCT_HDBan


---Nhanvien_HoaDonNhap---
create proc themNV
@MaNV int,
@HoTen nvarchar(30),
@NgaySinh date,
@GioiTinh nvarchar(4),
@PhuCap float,
@LuongCB float,
@DienThoai nvarchar(15)
as
insert into tblNhanVien(iMaNV, sHoTen, dNgaySinh, sGioiTinh, fPhuCap, fLuongCB, sDienThoai)
values (@MaNV,@HoTen,@NgaySinh,@GioiTinh,@PhuCap,@LuongCB,@DienThoai) 

create proc suaNV 
@MaNV int,
@HoTen nvarchar(30),
@NgaySinh date,
@GioiTinh nvarchar(4),
@PhuCap float,
@LuongCB float,
@DienThoai nvarchar(15)
as
	UPDATE tblNhanVien SET sHoTen = @HoTen, dNgaySinh = @NgaySinh, sGioiTinh = @GioiTinh, fPhuCap = @PhuCap, fLuongCB = @LuongCB, sDienThoai = @DienThoai
	WHERE iMaNV = @MaNV

create proc xoaNV
@MaNV int
as
delete from tblNhanVien where iMaNV = @MaNV



--=================
--=================
create view HoaDonNhap
as
select iMaHD , tblNhanVien.iMaNV , tblNhanVien.sHoTen , dNgayNhapSP ,sTrangThai
from tblHoaDonNhap, tblNhanVien
where tblNhanVien.iMaNV = tblHoaDonNhap.iMaNV

create proc themHD
@mahd int,
@manv int,
@ngaylap date,
@trangthai nvarchar(30)
as
	insert into tblHoaDonNhap (iMaHD, iMaNV, dNgayNhapSP,sTrangThai)
	values (@mahd, @manv, @ngaylap,@trangthai)

create proc suaHD
@mahd int,
@manv int,
@ngaylap date
as
	update tblHoaDonNhap set dNgayNhapSP = @ngaylap, iMaNV = @manv where iMaHD = @mahd

create proc xoaHD
@mahd int
as
	delete tblHoaDonNhap where iMaHD = @mahd

--====================
alter table tblHoaDonNhap
add fTongTien float

UPDATE dbo.tblHoaDonNhap
SET fTongTien = (SELECT sum (fGiaNhap*iSoLuong) FROM tblCT_HDNhap WHERE tblCT_HDNhap.iMaHD=tblHoaDonNhap.iMaHD)
FROM tblHoaDonNhap,tblCT_HDNhap
WHERE tblCT_HDNhap.iMaHD=tblHoaDonNhap.iMaHD

--bang nha cung cap
 create proc XoaNhaCC
(@MaNCC int)
 as
 delete from tblNhaCC
 where iMaNCC=@MaNCC

 create proc ThemNhaCC
(@MaNCC int, @tenNCC nvarchar(30),@diachi nvarchar(30),@SDT int)
 as
 insert into tblNhaCC(iMaNCC, sTenNCC, sDiaChi, sSDT)
values(@MaNCC , @tenNCC ,@diachi ,@SDT )

create proc SuaNHaCC
(@maNCC int,@tenNCC nvarchar(30),@diachi nvarchar(30),@sdt nvarchar(30))
as
update tblNhaCC
set sTenNCC=@tenNCC ,sDiaChi=@diachi,@sdt=sSDT
where @maNCC=iMaNCC

drop proc SuaNHaCC

--bang san pham

create proc Xoasp
(@Masp nvarchar(50))
 as
 delete from tblSanPham
 where sMaSP=@Masp

 create proc Themsp
(@MaNCC int,
@masp nvarchar(30),
@tensp nvarchar(30),
@Soluong int,
@giahang float,
@trongluong float,
@mausac nvarchar(30),
@hangsanpham nvarchar(30),
@ngayhethan datetime)
 as
insert into tblSanPham(iMaNCC,sMaSP, sTenSP, iSoLuong, fGiaHang,fTrongLuong,sMauSac,sHangSanPham,dNgayHetHan)
values(@MaNCC ,
@masp,
@tensp ,
@Soluong ,
@giahang ,
@trongluong ,
@mausac ,
@hangsanpham ,
@ngayhethan )



create proc SuaSP
(@MaNCC int,
@masp nvarchar(30),
@tensp nvarchar(30),
@Soluong int,
@giahang float,
@trongluong float,
@mausac nvarchar(30),
@hangsanpham nvarchar(30),
@ngayhethan datetime)
as
update tblSanPham
set 
iMaNCC=@MaNCC ,
sTenSP=@tensp ,
iSoLuong=@Soluong ,
fGiaHang=@giahang ,
fTrongLuong=@trongluong ,
sMauSac=@mausac ,
sHangSanPham=@hangsanpham ,
dNgayHetHan=@ngayhethan
where sMaSP= @masp

select*from tblCT_HDNhap
select*from tblHoaDonNhap

create view SanPham
  as
  select sMaSP,StenSP,sTenNCC,iSoLuong,fGiaHang,fTrongLuong,sMauSac,sHangSanPham,dNgayHetHan,tblNhaCC.iMaNCC
  from tblSanpham,tblNhaCC
  where tblSanpham.iMaNCC=tblNhaCC.iMaNCC

  ----Chi tiet hóa đơn nhập

  Create procedure themCTHDN
  @iMaHD int,
  @sMaSP NVARCHAR(30),
  @fGiaNhap float,
  @iSoluong int
  as
  BEGIN
	INSERT INTO dbo.tblCT_HDNhap
	Values(@iMaHD,@sMaSP,@fGiaNhap,@iSoluong)
  end


  execute dbo.themCTHDN @iMaHD = 455,
						@sMaSP = 'h55',
						@fGiaNhap = 30000,
						@iSoluong = 200


 create procedure xoaCT_HDN
  @iMaHD int, @iMaSP int
  as
  begin
	if EXISTS (SELECT * FROM dbo.tblCT_HDNhap WHERE @iMaHD = iMaHD and @iMaSP = sMaSP )
		begin
			delete dbo.tblCT_HDNhap where iMaHD = @iMaHD  and @iMaSP = sMaSP
		end
	else
		print N'hoa don not exist'
	end

----Chi tiết hóa đơn bán
  Create procedure themCTHDB
  @iMaHD int,
  @sMaSP nvarchar(30),
  @fGiaban float,
  @iSoluong int
  as
  BEGIN
	INSERT INTO dbo.tblCT_HDBan
	Values(
	@iMaHD,@sMaSP,@fGiaban,@iSoluong)
  end
  select*from tblCT_HDBan

  
  create proc Xoa_CTHDBan
  @iMaHD int, @iMaSP int
  as
  delete dbo.tblCT_HDNhap where iMaHD = @iMaHD  and @iMaSP = sMaSP
 