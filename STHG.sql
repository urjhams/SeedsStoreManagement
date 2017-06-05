use master
GO
If OBJECT_ID('STHG') is not Null
	Drop Database STHG
GO 

create database STHG
On (
   Name= STHG,
   Filename='D:\Database\STHG.mdf',
   Size=5MB,
   Maxsize=unlimited,
   FileGrowth=10%
)
LOG ON
(	Name = 'STHG_LOG',
	Filename = 'D:\DATABASE\STHG_Log.ldf',
	Size = 5Mb,
	Maxsize = unlimited,
	FileGrowth=10%
)
GO

use STHG
GO

--table

create table tbl_quyen
(
pk_maquyen varchar(5) not null primary key,
tenquyen varchar(15)
)


create table tbl_taikhoan
(
pk_tendangnhap varchar(15) primary key not null,
matkhau varchar(15),
fk_maquyen varchar(5) references tbl_quyen(pk_maquyen)
)
alter table tbl_taikhoan alter column fk_maquyen varchar(5) not null

create table tbl_nhanvien
(
pk_manv varchar(15) references tbl_taikhoan(pk_tendangnhap) primary key,
tennhanvien nvarchar(30),
ngaysinh date,
gioitinh nvarchar(3) check (gioitinh = N'Nam' or gioitinh = N'Nữ'),
diachi nvarchar(40),
sdt varchar(12),
)


create table tbl_khachhang
(
pk_makhachhang varchar(10) not null primary key,
tenkhachhang nvarchar(30),
ngaysinh date,
gioitinh nvarchar(3) check (gioitinh = N'Nam' or gioitinh = N'Nữ'),
diachi nvarchar(40),
sdt varchar(12)
)


create table tbl_nhacungcap
(
pk_manhacungcap varchar(10) not null primary key,
tennhacungcap nvarchar(30)
)


create table tbl_loaihatgiong
(
pk_maloaihatgiong varchar(10) not null primary key,
nhomloaihatgiong nvarchar(30)
)


create table tbl_hatgiong
(
pk_mahatgiong varchar(10) not null primary key,
tenhatgiong nvarchar(30),
mota nvarchar(100),
ngaysanxuat date,
hansudung date,
dongia int,
donvitinh nvarchar(5),
fk_maloaihatgiong varchar(10) references tbl_loaihatgiong(pk_maloaihatgiong),
soluong int
)
alter table tbl_hatgiong alter column fk_maloaihatgiong varchar(10) not null

create table tbl_phieunhap
(
pk_maphieunhap varchar(10) not null primary key,
ngaynhap date,
fk_manv varchar(15) references tbl_nhanvien(pk_manv),
fk_manhacungcap varchar(10) not null
)
alter table tbl_phieunhap alter column fk_manv varchar(15) not null
alter table tbl_phieunhap add constraint phieunhap_nhacungcap foreign key (fk_manhacungcap) references tbl_nhacungcap(pk_manhacungcap)

create table tbl_chitietphieunhap
(
pk_machitietphieunhap int not null primary key identity,
fk_mahatgiong varchar(10) references tbl_hatgiong(pk_mahatgiong),
soluongnhap int,
fk_maphieunhap varchar(10) references tbl_phieunhap(pk_maphieunhap)
)
alter table tbl_chitietphieunhap alter column fk_mahatgiong varchar(10) not null
alter table tbl_chitietphieunhap alter column fk_maphieunhap varchar(10) not null
alter table tbl_chitietphieunhap add gianhap int
select * from tbl_chitietphieunhap
create table tbl_hoadon
(
pk_mahoadon varchar(10) not null primary key,
ngayban date,
fk_manv varchar(15) references tbl_nhanvien(pk_manv),
fk_makhachhang varchar(10) references tbl_khachhang(pk_makhachhang)
)
alter table tbl_hoadon alter column fk_manv varchar(15) not null
alter table tbl_hoadon alter column fk_makhachhang varchar(10) not null

create table tbl_chitiethoadon
(
pk_machitiethoadon int not null primary key identity,
fk_mahatgiong varchar(10) references tbl_hatgiong(pk_mahatgiong),
soluong int,
giaban int,
fk_mahoadon varchar(10) references tbl_hoadon(pk_mahoadon)
)
alter table tbl_chitiethoadon alter column fk_mahatgiong varchar(10) not null
alter table tbl_chitiethoadon alter column fk_mahoadon varchar(10) not null

--proc
create proc sp_dangnhap
(	
@tendangnhap varchar(15),
@matkhau char(15)
)
as
begin
	select pk_tendangnhap,fk_maquyen
	from tbl_taikhoan
	where pk_tendangnhap = @tendangnhap AND matkhau = @matkhau
end


create proc sp_themtaikhoan
(
@tendangnhap varchar(15),
@matkhau varchar(15),
@quyen varchar(10)
)
as
begin
	insert into tbl_taikhoan(pk_tendangnhap,matkhau,fk_maquyen)
	values (@tendangnhap,@matkhau,@quyen)
end


create proc sp_suataikhoan
(
@tendangnhap varchar(15),
@matkhau varchar(15),
@quyen varchar(10)
)
as
begin
update tbl_taikhoan
set matkhau = @matkhau, fk_maquyen = @quyen
where pk_tendangnhap = @tendangnhap
end

create proc sp_xemtaikhoan
(
@tendangnhap varchar(15)
)
as
begin
	select pk_tendangnhap as [Tài khoản],
		   matkhau as [Mật khẩu],
		   fk_maquyen as [Quyền]
	from tbl_taikhoan
	where pk_tendangnhap = @tendangnhap
end


create proc sp_doimatkhau
(
@tendangnhap varchar(15),
@matkhau varchar(15)
)
as
begin
	update tbl_taikhoan
	set matkhau = @matkhau
	where pk_tendangnhap = @tendangnhap
end


go
create proc sp_themnhanvien
(
@pk_manv varchar(15),
@tennhanvien nvarchar(30),
@ngaysinh date,
@gioitinh nvarchar(3),
@diachi nvarchar(40),
@sdt varchar(12)
)
as
begin
	insert into tbl_nhanvien(pk_manv,tennhanvien,ngaysinh,gioitinh,diachi,sdt)
	values (@pk_manv,@tennhanvien,@ngaysinh,@gioitinh,@diachi,@sdt)
end


create proc sp_xemnhanvien
(
@pk_manv varchar(10)
)
as
begin
	select pk_manv as [Mã nhân viên],
		   tennhanvien as [Tên nhân viên],
		   ngaysinh as [Ngày sinh],
		   gioitinh as [Giới tính],
	       diachi as [Địa chỉ],
		   sdt as [Số điện thoại]
	from tbl_nhanvien
	where pk_manv = @pk_manv
end
go
create proc sp_suanhanvien
(
@pk_manv varchar(15),
@tennhanvien nvarchar(30),
@ngaysinh date,
@gioitinh nvarchar(3),
@diachi nvarchar(40),
@sdt varchar(12)
)
as
begin
	update tbl_nhanvien
	set tennhanvien = @tennhanvien, ngaysinh = @ngaysinh, gioitinh = @gioitinh, diachi = @diachi, sdt = @sdt
	where pk_manv = @pk_manv
end
select * from tbl_nhanvien

create proc sp_xoanhanvien
(
@pk_manv varchar(10)
)
as
begin
	delete from tbl_nhanvien
	where pk_manv= @pk_manv
end


create proc sp_themkhachhang
(
@pk_makhachhang varchar(10),
@tenkhachhang nvarchar(30),
@ngaysinh date,
@gioitinh nvarchar(3),
@diachi nvarchar(40),
@sdt varchar(12)
)
as
begin
	insert into tbl_khachhang(pk_makhachhang,tenkhachhang,ngaysinh,gioitinh,diachi,sdt)
	values (@pk_makhachhang,@tenkhachhang,@ngaysinh,@gioitinh,@diachi,@sdt)
end


create proc sp_xemkhachhang
(
@pk_makhachhang varchar(10)
)
as
begin
	select pk_makhachhang as [Mã khách hàng],
		   tenkhachhang as [Tên khách hàng],
		   ngaysinh as [Ngày sinh],
		   gioitinh as [Giới tính],
		   diachi as [Địa chỉ],
		   sdt as [Số điện thoại]
	from tbl_khachhang
	where pk_makhachhang = @pk_makhachhang
end


create proc sp_suakhachhang
(
@pk_makhachhang varchar(10),
@tenkhachhang nvarchar(30),
@ngaysinh date,
@gioitinh nvarchar(3),
@diachi nvarchar(40),
@sdt varchar(12)
)
as
begin
	update tbl_khachhang
	set tenkhachhang = @tenkhachhang, ngaysinh = @ngaysinh, gioitinh = @gioitinh, diachi = @diachi, sdt = @sdt
	where pk_makhachhang = @pk_makhachhang
end
----------------------xoa KH
create proc sp_get_CTHD_fromKH
(@maKH varchar(10))
as
begin
	select pk_machitiethoadon from tbl_chitiethoadon inner join tbl_hoadon on tbl_chitiethoadon.fk_mahoadon = tbl_hoadon.pk_mahoadon
	where tbl_hoadon.fk_makhachhang = @maKH
end

go
create proc sp_del_CTHD
(@maCTHD varchar(10))
as
begin
	delete from tbl_chitiethoadon where tbl_chitiethoadon.pk_machitiethoadon = @maCTHD
end

go

create proc sp_del_HDnKH
(
@pk_makhachhang varchar(10)
)
as
begin
	delete from tbl_hoadon where fk_makhachhang = @pk_makhachhang
	delete from tbl_khachhang where pk_makhachhang = @pk_makhachhang
end
go

-------------------------------------------------------------------------------------------
go
create proc sp_themhatgiong
(
@pk_mahatgiong varchar(10),
@tenhatgiong nvarchar(30),
@mota nvarchar(100),
@ngaysanxuat date,
@hansudung date,
@dongia int,
@donvitinh nvarchar(5),
@fk_maloaihatgiong varchar(10),
@sl int
)
as
begin
	insert into tbl_hatgiong(pk_mahatgiong,tenhatgiong,mota,ngaysanxuat,hansudung,dongia,donvitinh,fk_maloaihatgiong,soluong)
	values (@pk_mahatgiong,@tenhatgiong,@mota,@ngaysanxuat,@hansudung,@dongia,@donvitinh,@fk_maloaihatgiong,@sl)
end

drop proc sp_themhatgiong

insert into tbl_hatgiong
values ('HGAQ1','CTMV','HCAQ','TM1','Táo mỹ 1','2017-01-01','2017-01-03',100000,'Gói')

create proc sp_xemhatgiong
(
@pk_mahatgiong varchar(10)
)
as
begin
	select  pk_mahatgiong as [Mã hạt giống],
			tennhacungcap as [Tên nhà cung cấp],
			nhomloaihatgiong as [Nhóm loại hạt giống],
			tenhatgiong as [Tên hạt giống],
			mota as [Mô tả],
			ngaysanxuat as [Ngày sản xuất],
			hansudung as [Hạn sử dụng],
			dongia as [Đơn giá],
			donvitinh as [Đơn vị tính]
	from tbl_hatgiong a inner join tbl_nhacungcap b on (a.fk_manhacungcap = b.pk_manhacungcap)
						inner join tbl_loaihatgiong c on (a.fk_maloaihatgiong = c.pk_maloaihatgiong)
end

go
create proc sp_suahatgiong
(
@pk_mahatgiong varchar(10),
@tenhatgiong nvarchar(30),
@mota nvarchar(100),
@ngaysanxuat date,
@hansudung date,
@dongia int,
@donvitinh nvarchar(5),
@fk_maloaihatgiong varchar(10),
@sl int
)
as
begin
	update tbl_hatgiong
	set tenhatgiong = @tenhatgiong, mota = @mota, ngaysanxuat = @ngaysanxuat, hansudung = @hansudung,
	 dongia = @dongia, donvitinh = @donvitinh, fk_maloaihatgiong = @fk_maloaihatgiong, soluong = @sl
where pk_mahatgiong = @pk_mahatgiong
end
drop proc sp_suahatgiong

select * from tbl_hatgiong

create proc sp_xoahatgiong
(
@pk_mahatgiong varchar(10)
)
as
begin
	delete from tbl_hatgiong
	where pk_mahatgiong = @pk_mahatgiong
end


create proc sp_themnhacungcap
(
@pk_manhacungcap varchar(10),
@tennhacungcap nvarchar(30)
)
as
begin
	insert into tbl_nhacungcap(pk_manhacungcap,tennhacungcap)
	values (@pk_manhacungcap,@tennhacungcap)
end


create proc sp_xemnhacungcap
(
@pk_manhacungcap varchar(10)
)
as
begin
	select pk_manhacungcap as [Mã nhà cung cấp],
		   tennhacungcap as [Tên nhà cung cấp]
	from tbl_nhacungcap
	where pk_manhacungcap = @pk_manhacungcap
end


create proc sp_suanhacungcap
(
@pk_manhacungcap varchar(10),
@tennhacungcap nvarchar(30)
)
as
begin
	update tbl_nhacungcap
	set tennhacungcap = @tennhacungcap
	where pk_manhacungcap = @pk_manhacungcap
end

go
create proc sp_xoanhacungcap
(
@pk_manhacungcap varchar(10)
)
as
begin
	update tbl_nhacungcap set tennhacungcap = null
	where pk_manhacungcap = @pk_manhacungcap
end


create proc sp_themloaihatgiong
(
@pk_maloaihatgiong varchar(10),
@nhomloaihatgiong nvarchar(30)
)
as
begin
	insert into tbl_loaihatgiong(pk_maloaihatgiong,nhomloaihatgiong)
	values (@pk_maloaihatgiong,@nhomloaihatgiong)
end


create proc sp_xemloaihatgiong
(
@pk_maloaihatgiong varchar(10)
)
as
begin
	select pk_maloaihatgiong as [Mã loại hạt giống],
		   nhomloaihatgiong as [Nhóm loại hạt giống]
	from tbl_loaihatgiong
	where pk_maloaihatgiong = @pk_maloaihatgiong
end


create proc sp_sualoaihatgiong
(
@pk_maloaihatgiong varchar(10),
@nhomloaihatgiong nvarchar(30)
)
as
begin
	update tbl_loaihatgiong
	set nhomloaihatgiong = @nhomloaihatgiong
	where pk_maloaihatgiong = @pk_maloaihatgiong
end


create proc sp_xoaloaihatgiong
(
@pk_maloaihatgiong varchar(10)
)
as
begin
	delete from tbl_loaihatgiong
	where pk_maloaihatgiong = @pk_maloaihatgiong
end


create proc sp_themphieunhap
(
@pk_maphieunhap varchar(10),
@fk_manv varchar(10),
@ngaynhap date,
@manhacc varchar(10)
)
as
begin
	insert into tbl_phieunhap
	values (@pk_maphieunhap,@ngaynhap,@fk_manv,@manhacc)
end
select * from tbl_phieunhap
delete from tbl_phieunhap

create proc sp_xemphieunhap
(
@pk_maphieunhap varchar(10)
)
as
begin
	select pk_maphieunhap as [Mã phiếu nhập],
		   tennhanvien as [Tên nhân viên],
		   ngaynhap as [Ngày nhập]
	from tbl_phieunhap a inner join tbl_nhanvien b on (a.fk_manv = b.pk_manv)
end


create proc sp_suaphieunhap
(
@pk_maphieunhap varchar(10),
@fk_manv varchar(10),
@ngaynhap date
)
as
begin
	update tbl_phieunhap
	set fk_manv = @fk_manv, ngaynhap = @ngaynhap
	where pk_maphieunhap = @pk_maphieunhap
end


create proc sp_themchitietphieunhap
(
@pk_machitietphieunhap varchar(10),
@fk_mahatgiong varchar(10),
@soluongnhap int,
@fk_maphieunhap varchar(10)
)
as
begin
	insert into tbl_chitietphieunhap(pk_machitietphieunhap,fk_mahatgiong,soluongnhap,fk_maphieunhap)
	values(@pk_machitietphieunhap,@fk_mahatgiong,@soluongnhap,@fk_maphieunhap)
end


create proc sp_xemchitietphieunhap
(
@pk_machitietphieunhap varchar(10)
)
as
begin
	select pk_machitietphieunhap as [Mã chi tiết phiếu nhập],
		   tenhatgiong as [Tên hạt giống],
		   soluongnhap as [Số lượng nhập],
		   fk_maphieunhap as [Mã phiếu nhập]
	from tbl_chitietphieunhap a inner join tbl_hatgiong b on (a.fk_mahatgiong = b.pk_mahatgiong)
	where pk_machitietphieunhap = @pk_machitietphieunhap
end


create proc sp_suachitietphieunhap
(
@pk_machitietphieunhap varchar(10),
@fk_mahatgiong varchar(10),
@soluongnhap int,
@fk_maphieunhap varchar(10)
)
as
begin
	update tbl_chitietphieunhap
	set fk_mahatgiong = @fk_mahatgiong, soluongnhap = @soluongnhap, fk_maphieunhap = @fk_maphieunhap
	where pk_machitietphieunhap = @pk_machitietphieunhap
end


create proc sp_themhoadon
(
@pk_mahoadon varchar(10),
@ngayban date,
@fk_manv varchar(10),
@fk_makhachhang varchar(10)
)
as
begin
	insert into tbl_hoadon(pk_mahoadon,ngayban,fk_manv,fk_makhachhang)
	values(@pk_mahoadon,@ngayban,@fk_manv,@fk_makhachhang)
end
exec sp_themhoadon 'HD002',null,'',''

create proc sp_xemhoadon
(
@pk_mahoadon varchar(10)
)
as
begin
	select pk_mahoadon as [Mã hóa đơn],
		   ngayban as [Ngày bán],
		   tennhanvien as [Người lập],
		   tenkhachhang as [Tên khách hàng]
	from tbl_hoadon a inner join tbl_nhanvien b on (a.fk_manv = b.pk_manv)
					  inner join tbl_khachhang c on (a.fk_makhachhang = c.pk_makhachhang)
	where pk_mahoadon = @pk_mahoadon
end


create proc sp_suahoadon
(
@pk_mahoadon varchar(10),
@ngayban date,
@fk_manv varchar(10),
@fk_makhachhang varchar(10)
)
as
begin
	update tbl_hoadon
	set ngayban = @ngayban, fk_manv = @fk_manv, fk_makhachhang = @fk_makhachhang
	where pk_mahoadon = @pk_mahoadon
end


create proc sp_themchitiethoadon
(
@pk_machitiethoadon varchar(10),
@fk_mahatgiong varchar(10),
@soluong int,
@giaban int,
@fk_mahoadon varchar(10)
)
as
begin
	insert into tbl_chitiethoadon(pk_machitiethoadon,fk_mahatgiong,soluong,giaban,fk_mahoadon)
	values(@pk_machitiethoadon,@fk_mahatgiong,@soluong,@giaban,@fk_mahoadon)
end


create proc sp_xemchitiethoadon
(
@pk_machitiethoadon varchar(10)
)
as
begin
	select pk_machitiethoadon as [Mã chi tiết hóa đơn],
		   tenhatgiong as [Tên hạt giống],
		   soluong as [Số lượng],
		   giaban as [Giá bán],
		   fk_mahoadon as [Mã hóa đơn]
	from tbl_chitiethoadon a inner join tbl_hatgiong b on (a.fk_mahatgiong = b.pk_mahatgiong)
	where pk_machitiethoadon = @pk_machitiethoadon
end


create proc sp_suachitiethoadon
(
@pk_machitiethoadon varchar(10),
@fk_mahatgiong varchar(10),
@soluong int,
@giaban int,
@fk_mahoadon varchar(10)
)
as
begin
	update tbl_chitiethoadon
	set fk_mahatgiong = @fk_mahatgiong, soluong = @soluong, giaban = @giaban, fk_mahoadon = @fk_mahoadon
	where pk_machitiethoadon = @pk_machitiethoadon
end


create view v_nhanvien
as
select  pk_manv as [Mã nhân viên],
	    tennhanvien as [Tên nhân viên],
		ngaysinh as [Ngày sinh],
		gioitinh as [Giới tính],
	    diachi as [Địa chỉ],
		sdt as [Số điện thoại]
from tbl_nhanvien

create view v_taikhoan
as
select pk_tendangnhap
from tbl_taikhoan

drop view v_nhanvien


create view v_khachhang
as
select  pk_makhachhang as [Mã khách hàng],
		tenkhachhang as [Tên khách hàng],
		ngaysinh as [Ngày sinh],
		gioitinh as [Giới tính],
		diachi as [Địa chỉ],
		sdt as [Số điện thoại]
from tbl_khachhang


create view v_hatgiong
as
select		pk_mahatgiong as [Mã hạt giống],
			nhomloaihatgiong as [Nhóm loại hạt giống],
			tenhatgiong as [Tên hạt giống],
			mota as [Mô tả],
			ngaysanxuat as [Ngày sản xuất],
			hansudung as [Hạn sử dụng],
			dongia as [Đơn giá],
			donvitinh as [Đơn vị tính],
			soluong as [Số lượng]
from tbl_hatgiong a inner join tbl_loaihatgiong c on (a.fk_maloaihatgiong = c.pk_maloaihatgiong)

drop view v_nhacungcap
create view v_nhacungcap
as
select pk_manhacungcap as [Mã nhà cung cấp],
	   tennhacungcap as [Tên nhà cung cấp]
from tbl_nhacungcap 


drop view v_loaihatgiong
create view v_loaihatgiong
as
select pk_maloaihatgiong as [Mã loại hạt giống],
	   nhomloaihatgiong as [Nhóm loại hạt giống]
from tbl_loaihatgiong


create view v_tk
as
select	   pk_tendangnhap as [Tài khoản],
		   matkhau as [Mật khẩu],
		   fk_maquyen as [Quyền]
from tbl_taikhoan


create view v_lhg
as
select	   pk_maloaihatgiong as [Mã loại hạt giống],
		   nhomloaihatgiong as [Nhóm loại hạt giống]
from tbl_loaihatgiong


create view v_ncc
as
select	   pk_manhacungcap as [Mã nhà cung cấp],
		   tennhacungcap as [Tên nhà cung cấp]
from tbl_nhacungcap


create view v_quyen
as
select * from tbl_quyen


create view v_hoadon
as
select     pk_mahoadon as [Mã hóa đơn],
		   ngayban as [Ngày lập],
		   tennhanvien as [Người lập],
		   tenkhachhang as [Tên khách hàng]
from tbl_hoadon a inner join tbl_nhanvien b on (a.fk_manv = b.pk_manv)
				  inner join tbl_khachhang c on (a.fk_makhachhang = c.pk_makhachhang)

go
create proc xem_all_NV
as
begin
	SELECT [Mã nhân viên], [Tên nhân viên], [Ngày sinh], [Giới tính], [Địa chỉ], [Số điện thoại] FROM dbo.v_nhanvien
end

go
Create Proc sp_searchnv
(
	@tennhanvien nvarchar(30)
)
As
Begin
	SELECT [Mã nhân viên], [Tên nhân viên], [Ngày sinh], [Giới tính], [Địa chỉ], [Số điện thoại] FROM dbo.v_nhanvien
	Where /*tennhanvien*/ [Tên nhân viên] LIKE '%' + @tennhanvien + '%';
End

go
create proc sp_searchnv_nameOrdc
(
	@ten nvarchar(30),
	@gt nvarchar(3),
	@dc nvarchar(40)
)
as
begin
	select [Mã nhân viên], [Tên nhân viên], [Ngày sinh], [Giới tính], [Địa chỉ], [Số điện thoại] FROM dbo.v_nhanvien 
	where [Tên nhân viên] like '%' + @ten + '%' and [Giới tính] like '%' + @gt + '%' and [Địa chỉ] like '%' + @dc + '%';
end;
go
create proc xem_all_Hat
as
begin
	select pk_mahatgiong as [Mã hạt giống], tenhatgiong as [Tên hạt giống], mota as [Mô tả], ngaysanxuat as [Ngày sản xuất],
	hansudung as [Hạn sử dụng], dongia as [Đơn giá], donvitinh as [Đơn vị tính], tbl_loaihatgiong.nhomloaihatgiong as [Nhóm loại hạt giống], tbl_hatgiong.soluong as [Số lượng]
	from tbl_hatgiong inner join tbl_loaihatgiong on tbl_hatgiong.fk_maloaihatgiong = tbl_loaihatgiong.pk_maloaihatgiong
end
go
drop proc xem_all_Hat
create proc sp_searchHat
(
	@ten nvarchar(30),
	@nhomloai nvarchar(30)
)
as
begin
	select pk_mahatgiong as [Mã hạt giống], tenhatgiong as [Tên hạt giống], mota as [Mô tả], ngaysanxuat as [Ngày sản xuất],
	hansudung as [Hạn sử dụng], dongia as [Đơn giá], donvitinh as [Đơn vị tính], tbl_loaihatgiong.nhomloaihatgiong as [Nhóm loại hạt giống]
	from tbl_hatgiong inner join tbl_loaihatgiong on tbl_hatgiong.fk_maloaihatgiong = tbl_loaihatgiong.pk_maloaihatgiong
	where tenhatgiong LIKE '%' + @ten + '%' and tbl_loaihatgiong.nhomloaihatgiong like '%' + @nhomloai + '%';
end

drop proc sp_searchHat

go
create proc xem_all_KH
as
begin
	select pk_makhachhang as [Mã khách hàng], tenkhachhang as [Tên khách hàng], ngaysinh as [Ngày sinh], gioitinh as [Giới tính], diachi as [Địa chỉ], sdt as [Số điện thoại]
	from tbl_khachhang
end

go
create proc sp_searchKH
(
	@ten nvarchar(30),
	@dc nvarchar(40),
	@sdt varchar(12),
	@gt nvarchar(3)
)
as
begin
	select pk_makhachhang as [Mã khách hàng], tenkhachhang as [Tên khách hàng], ngaysinh as [Ngày sinh], gioitinh as [Giới tính], diachi as [Địa chỉ], sdt as [Số điện thoại]
	from tbl_khachhang where tenkhachhang LIKE '%' + @ten + '%' and gioitinh like '%' + @gt + '%' and diachi like '%' + @dc + '%' and sdt like '%' + @sdt + '%';
end

go
create proc xem_all_HD
as
begin
	select tbl_hoadon.pk_mahoadon as [Mã hóa đơn], ngayban as [Ngày lập], tbl_nhanvien.tennhanvien as [Người lập], tbl_khachhang.tenkhachhang as [Tên khách hàng]
	from (tbl_hoadon inner join tbl_nhanvien on tbl_hoadon.fk_manv = tbl_nhanvien.pk_manv) inner join tbl_khachhang on tbl_hoadon.fk_makhachhang = tbl_khachhang.pk_makhachhang
end

go
create proc xem_all_Phieunhap
as
begin
	select * from v_phieunhap
end
go
create view v_phieunhap
as
select  pk_maphieunhap as [Mã phiếu nhập],
		tennhanvien as [Tên nhân viên],
		ngaynhap as [Ngày nhập],
		tennhacungcap as [Nhà cung cấp]
from tbl_phieunhap a inner join tbl_nhanvien b on (a.fk_manv = b.pk_manv)
					inner join tbl_nhacungcap c on a.fk_manhacungcap = c.pk_manhacungcap

go
create proc sp_newest_PN
as
begin
	select top 1 pk_maphieunhap from tbl_phieunhap order by pk_maphieunhap desc
end

go 


go
create proc sp_ct1HD
(
	@ma varchar(10)
)
as
begin
	
end
select * from v_phieunhap

select * from tbl_hatgiong
select * from tbl_phieunhap

create view v_hg
as
select pk_mahatgiong,tenhatgiong
from tbl_hatgiong


create proc sp_rphd
(
@mahoadon varchar(10)
)
as
select tenhatgiong as [Tên hạt giống],
	   a.soluong as [Số lượng],
	   a.soluong * c.dongia as [Giá bán]
from tbl_chitiethoadon a inner join tbl_hoadon b on (a.fk_mahoadon = b.pk_mahoadon)
						 inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
where pk_mahoadon = @mahoadon

drop proc sp_rphd

select * from tbl_hoadon


--select tbl_hatgiong.tenhatgiong as [Tên hạt giống], soluongnhap as [Số lượng nhập], gianhap as [Giá nhập] from tbl_chitietphieunhap inner join tbl_hatgiong on tbl_hatgiong.pk_mahatgiong = tbl_chitietphieunhap.fk_mahatgiong where fk_maphieunhap = 

drop proc sp_chitietHD
go 
create proc sp_chitietHD
(@mahd varchar(20))
as
begin
if @mahd = ''
begin
	select tbl_chitiethoadon.fk_mahoadon as [Mã hóa đơn],
	tbl_nhanvien.tennhanvien as [Nhân viên lập],
	tbl_khachhang.tenkhachhang as [Khách hàng],
	tbl_hoadon.ngayban as [Ngày lập],
	tbl_chitiethoadon.fk_mahatgiong as [Mã hạt giống],
	tbl_hatgiong.tenhatgiong as [Tên hạt giống],
	tbl_chitiethoadon.soluong as [Số lượng],
	tbl_chitiethoadon.giaban as [giá bán],
	tbl_chitiethoadon.soluong * tbl_hatgiong.dongia as [tổng giá]
	from (tbl_chitiethoadon inner join ((tbl_hoadon inner join tbl_khachhang on tbl_hoadon.fk_makhachhang = tbl_khachhang.pk_makhachhang) inner join tbl_nhanvien on tbl_hoadon.fk_manv = tbl_nhanvien.pk_manv) on tbl_chitiethoadon.fk_mahoadon = tbl_hoadon.pk_mahoadon) inner join tbl_hatgiong on tbl_chitiethoadon.fk_mahatgiong = tbl_hatgiong.pk_mahatgiong
end
else 
begin
	select tbl_chitiethoadon.fk_mahoadon as [Mã hóa đơn],
	tbl_nhanvien.tennhanvien as [Nhân viên lập],
	tbl_khachhang.tenkhachhang as [Khách hàng],
	tbl_hoadon.ngayban as [Ngày lập],
	tbl_chitiethoadon.fk_mahatgiong as [Mã hạt giống],
	tbl_hatgiong.tenhatgiong as [Tên hạt giống],
	tbl_chitiethoadon.soluong as [Số lượng],
	tbl_chitiethoadon.giaban as [giá bán],
	tbl_chitiethoadon.soluong * tbl_hatgiong.dongia as [tổng giá]
	from (tbl_chitiethoadon inner join ((tbl_hoadon inner join tbl_khachhang on tbl_hoadon.fk_makhachhang = tbl_khachhang.pk_makhachhang) inner join tbl_nhanvien on tbl_hoadon.fk_manv = tbl_nhanvien.pk_manv) on tbl_chitiethoadon.fk_mahoadon = tbl_hoadon.pk_mahoadon) inner join tbl_hatgiong on tbl_chitiethoadon.fk_mahatgiong = tbl_hatgiong.pk_mahatgiong
	where tbl_chitiethoadon.fk_mahoadon = @mahd
end
end


create proc rp_pn
(
@mapn varchar(10)
)
as
begin
if @mapn = ''
begin
	select b.pk_maphieunhap as [Mã phiếu nhập],
	d.tennhanvien as [Tên nhân viên],
	c.tennhacungcap as [Tên nhà cung cấp],
	b.ngaynhap as [Ngày nhập],
	e.tenhatgiong as [Tên hạt giống],
	a.gianhap as [Giá nhập],
	a.soluongnhap as [Số lượng nhập],
	a.gianhap * a.soluongnhap as [Tổng giá]
	from tbl_chitietphieunhap a inner join tbl_phieunhap b on (a.fk_maphieunhap = b.pk_maphieunhap)
								inner join tbl_nhacungcap c on (b.fk_manhacungcap = c.pk_manhacungcap)
								inner join tbl_nhanvien d on (b.fk_manv = d.pk_manv)
								inner join tbl_hatgiong e on (a.fk_mahatgiong = e.pk_mahatgiong)
end
else
begin
	select b.pk_maphieunhap as [Mã phiếu nhập],
	d.tennhanvien as [Tên nhân viên],
	c.tennhacungcap as [Tên nhà cung cấp],
	b.ngaynhap as [Ngày nhập],
	e.tenhatgiong as [Tên hạt giống],
	a.gianhap as [Giá nhập],
	a.soluongnhap as [Số lượng nhập],
	a.gianhap * a.soluongnhap as [Tổng giá]
	from tbl_chitietphieunhap a inner join tbl_phieunhap b on (a.fk_maphieunhap = b.pk_maphieunhap)
								inner join tbl_nhacungcap c on (b.fk_manhacungcap = c.pk_manhacungcap)
								inner join tbl_nhanvien d on (b.fk_manv = d.pk_manv)
								inner join tbl_hatgiong e on (a.fk_mahatgiong = e.pk_mahatgiong)
	where a.fk_maphieunhap = @mapn
end
end


create proc rp_hb
(
@ngayban date
)
as
begin
if @ngayban = ''
begin
select c.tenhatgiong as [Tên hạt giống],
	   sum(a.soluong) as [Số lượng]
from tbl_chitiethoadon a inner join tbl_hoadon b on (a.fk_mahoadon = b.pk_mahoadon)
						 inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
group by c.tenhatgiong
end
else
begin
select c.tenhatgiong as [Tên hạt giống],
	   sum(a.soluong) as [Số lượng]
from tbl_chitiethoadon a inner join tbl_hoadon b on (a.fk_mahoadon = b.pk_mahoadon)
						 inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
where b.ngayban = @ngayban
group by c.tenhatgiong
end
end


create proc rp_hn
(
@ngaynhap date
)
as
begin
if @ngaynhap = ''
begin
select c.tenhatgiong as [Tên hạt giống],
	   sum(a.soluongnhap) as [Số lượng]
from tbl_chitietphieunhap a inner join tbl_phieunhap b on (a.fk_maphieunhap = b.pk_maphieunhap)
							inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
group by c.tenhatgiong
end
else
begin
select c.tenhatgiong as [Tên hạt giống],
	   sum(a.soluongnhap) as [Số lượng]
from tbl_chitietphieunhap a inner join tbl_phieunhap b on (a.fk_maphieunhap = b.pk_maphieunhap)
							inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
where b.ngaynhap = @ngaynhap
group by c.tenhatgiong
end
end


create proc rp_ht
as
begin
select tenhatgiong as [Tên hạt giống],
	   soluong as [Số lượng]
from tbl_hatgiong
end

create proc rp_dt
(
@ngay date
)
as
begin
if @ngay = ''
begin
select c.tenhatgiong as [Tên hạt giống],
	   a.soluong as [Số lượng],
	   a.soluong * c.dongia as [Tổng giá]
from tbl_chitiethoadon a inner join tbl_hoadon b on (a.fk_mahoadon = b.pk_mahoadon)
						 inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
end
else
begin
select c.tenhatgiong as [Tên hạt giống],
	   a.soluong as [Số lượng],
	   a.soluong * c.dongia as [Tổng giá]
from tbl_chitiethoadon a inner join tbl_hoadon b on (a.fk_mahoadon = b.pk_mahoadon)
						 inner join tbl_hatgiong c on (a.fk_mahatgiong = c.pk_mahatgiong)
where b.ngayban = @ngay
end
end


go 
create proc xem_all_Hatgiong
as
begin
	SELECT [Mã hạt giống], [Nhóm loại hạt giống], [Tên hạt giống], [Mô tả], [Ngày sản xuất], [Hạn sử dụng], [Đơn giá], [Đơn vị tính], [Số lượng] FROM v_hatgiong
end


------- so luong phai lon hon 0
alter table tbl_hatgiong add constraint check_SL_Hat check(soluong >= 0)
