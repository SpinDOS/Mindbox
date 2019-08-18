IF (DB_ID('Mindbox') IS NULL)
	CREATE DATABASE Mindbox;

GO

USE Mindbox;

DROP TABLE IF EXISTS dbo.[Product-Category];
DROP TABLE IF EXISTS dbo.Product;
DROP TABLE IF EXISTS dbo.Category;

CREATE TABLE dbo.Product
(
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  Name NVARCHAR(100)
);

CREATE TABLE dbo.Category
(
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  Name NVARCHAR(100)
);

CREATE TABLE dbo.[Product-Category]
(
  Product_Id UNIQUEIDENTIFIER,
  Category_Id UNIQUEIDENTIFIER,
  PRIMARY KEY (Product_Id, Category_Id),
  FOREIGN KEY (Product_Id) REFERENCES dbo.Product(Id),
  FOREIGN KEY (Category_Id) REFERENCES dbo.Category(Id)
);

DECLARE @category0Products UNIQUEIDENTIFIER = NEWID();
DECLARE @category1Product UNIQUEIDENTIFIER = NEWID();
DECLARE @category2ProductS UNIQUEIDENTIFIER = NEWID();

INSERT INTO dbo.Category (Id, Name) VALUES 
(@category0Products, 'Category no products'),
(@category1Product, 'Category one product'),
(@category2Products, 'Category two products');

DECLARE @product0Categories UNIQUEIDENTIFIER = NEWID();
DECLARE @product1Category UNIQUEIDENTIFIER = NEWID();
DECLARE @product2Categories UNIQUEIDENTIFIER = NEWID();
   
INSERT INTO dbo.Product (Id, Name) VALUES
(@product0Categories, 'Product no categories'),
(@product1Category, 'Product one category'),
(@product2Categories, 'Product two categories');

INSERT INTO dbo.[Product-Category] VALUES
(@product1Category, @category2Products),
(@product2Categories, @category2Products),
(@product2Categories, @category1Product);