create database CafePOSDB
go 
use CafePOSDB

go 
create table banan(
	maban int identity(1,1) primary key,
	tenban nvarchar(50) not NULL,
	trangthai nvarchar(20) default N'Trống'
);

create table danhmuc(
	madanhmuc int identity(1,1) primary key,
	tendanhmuc nvarchar(100) not NULL
);

create table monan(
	mamon int identity(1,1) primary key,
	tenmon nvarchar(100) not NULL,
	madanhmuc int foreign key references danhmuc(madanhmuc) on delete cascade,
	dongia decimal(18,2) not NULL check ( dongia >=0 )
);

create table hoadon(
	mahoadon int identity(1,1) primary key,
	maban int foreign key references banan(maban),
	giovao datetime not NULL default getdate(),
	giora datetime NULL,
	tongtien decimal(18,2) default 0,
	trangthai bit default 0
);

create table chitiethoadon(
	mahoadon int foreign key references hoadon(mahoadon),
	mamon int foreign key references monan(mamon),
	soluong int not NULL check ( soluong>0),
	dongia decimal(18,2) not NULL,
	primary key (mahoadon,mamon)
);
insert into banan (tenban) values (N'Bàn 01'), (N'Bàn 02'), (N'Bàn 03'), (N'Bàn 04'), (N'Bàn 05'), (N'Bàn 06');
insert into danhmuc (tendanhmuc) values (N'Cà phê'), (N'Trà sữa'), (N'Đồ ăn nhẹ');
insert into monan(tenmon, madanhmuc, dongia) values
(N'Cà phê đen', 1, 20000),
(N'Cà phê sữa', 1, 25000),
(N'Trà sữa Trân châu', 2, 35000),
(N'Bánh Mì Pa-tê', 3, 20000);