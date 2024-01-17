-- Tạo cơ sở dữ liệu (Database)
CREATE DATABASE Ecommerce;
GO

-- Sử dụng cơ sở dữ liệu mới tạo
USE Ecommerce;
GO

-- Tạo bảng Customer
CREATE TABLE Customer (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    FullName NVARCHAR(50),
    DateOfBirth DATE,
    Email NVARCHAR(100),
	IsDeleted BIT NOT NULL DEFAULT 0
);

-- Tạo bảng Shop
CREATE TABLE Shop (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(50),
    Location NVARCHAR(100),
	IsDeleted BIT NOT NULL DEFAULT 0
);

-- Tạo bảng Product
CREATE TABLE Product (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(50),
    Price DECIMAL(10, 2),
	IsDeleted BIT NOT NULL DEFAULT 0
);

-- Tạo bảng trung gian OrderDetail
CREATE TABLE OrderDetail (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    CustomerId UNIQUEIDENTIFIER,
    ShopId UNIQUEIDENTIFIER,
    ProductId UNIQUEIDENTIFIER,
	IsDeleted BIT NOT NULL DEFAULT 0
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
    FOREIGN KEY (ShopId) REFERENCES Shop(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
);