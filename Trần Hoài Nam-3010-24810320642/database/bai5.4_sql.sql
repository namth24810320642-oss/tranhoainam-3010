CREATE DATABASE HotelDB;
GO
USE HotelDB;
GO

CREATE TABLE phong (
    sophong VARCHAR(10) PRIMARY KEY,
    loaiphong NVARCHAR(50) NOT NULL,
    giatheogio DECIMAL(18,2) NOT NULL CHECK (giatheogio >= 0),
    trangthai NVARCHAR(30) DEFAULT N'Trống' -- 'Trống', 'Đang ở', 'Đang dọn dẹp'
);

CREATE TABLE khachhang (
    makh INT IDENTITY(1,1) PRIMARY KEY,
    hoten NVARCHAR(100) NOT NULL,
    cccd VARCHAR(20) UNIQUE NOT NULL,
    sodienthoai VARCHAR(15) NULL
);

CREATE TABLE dichvu (
    madv INT IDENTITY(1,1) PRIMARY KEY,
    tendv NVARCHAR(100) NOT NULL,
    dongia DECIMAL(18,2) NOT NULL CHECK (dongia >= 0)
);

CREATE TABLE phieudatphong (
    maphieu INT IDENTITY(1,1) PRIMARY KEY,
    sophong VARCHAR(10) FOREIGN KEY REFERENCES phong(sophong),
    makh INT FOREIGN KEY REFERENCES khachhang(makh),
    ngaynhanphong DATETIME NOT NULL DEFAULT GETDATE(),
    ngaytraphong DATETIME NULL,
    tongtienthanhtoan DECIMAL(18,2) DEFAULT 0
);

CREATE TABLE sudungdichvu (
    maphieu INT FOREIGN KEY REFERENCES phieudatphong(maphieu),
    madv INT FOREIGN KEY REFERENCES dichvu(madv),
    soluong INT NOT NULL CHECK (soluong > 0),
    thoigian DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (maphieu, madv, thoigian)
);
GO
USE HotelDB;
INSERT INTO phong (sophong, loaiphong, giatheogio, trangthai) VALUES
('P101', N'Đơn', 50000, N'Trống'),
('P102', N'Đôi', 80000, N'Trống'),
('P201', N'VIP', 150000, N'Trống');

select*from phong