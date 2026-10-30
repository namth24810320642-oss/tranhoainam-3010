CREATE DATABASE InventoryDB;
GO
USE InventoryDB;
GO

CREATE TABLE hanghoa (
    mahang INT IDENTITY(1,1) PRIMARY KEY,
    tenhang NVARCHAR(100) NOT NULL,
    donvitinh NVARCHAR(20) NOT NULL,
    soluongton INT DEFAULT 0 CHECK (soluongton >= 0),
    dongianhap DECIMAL(18,2) DEFAULT 0 CHECK (dongianhap >= 0),
    dongiaxuat DECIMAL(18,2) DEFAULT 0 CHECK (dongiaxuat >= 0)
);

CREATE TABLE phieuxuatnhap (
    maphieu INT IDENTITY(1,1) PRIMARY KEY,
    loaiphieu NVARCHAR(10) NOT NULL CHECK (loaiphieu IN (N'NHẬP', N'XUẤT')),
    ngaylap DATETIME DEFAULT GETDATE(),
    ghichu NVARCHAR(255) NULL
);

CREATE TABLE chitietphieu (
    maphieu INT FOREIGN KEY REFERENCES phieuxuatnhap(maphieu),
    mahang INT FOREIGN KEY REFERENCES hanghoa(mahang),
    soluong INT NOT NULL CHECK (soluong > 0),
    dongia DECIMAL(18,2) NOT NULL CHECK (dongia >= 0),
    PRIMARY KEY (maphieu, mahang)
);

-- DỮ LIỆU MẪU (SEED DATA)
INSERT INTO hanghoa (tenhang, donvitinh, soluongton, dongianhap, dongiaxuat) VALUES
(N'Cà phê hạt Arabica', N'Kg', 100, 150000, 200000),
(N'Sữa tươi Vinamilk 1L', N'Hộp', 50, 30000, 38000),
(N'Đường trắng', N'Kg', 200, 18000, 22000),
(N'Ly nhựa 500ml', N'Lốc', 30, 25000, 32000);
GO