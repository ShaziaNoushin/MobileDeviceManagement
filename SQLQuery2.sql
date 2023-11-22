CREATE TABLE MobileDevices
(
	MobileDeviceId INT PRIMARY KEY,
	MobileDeviceName NVARCHAR(40) NOT NULL,
	Price MONEY NOT NULL,
	Quantity INT NOT NULL,
	[RelaeseDate] DATE NOT NULL,
	Picture NVARCHAR(50) NOT NULL,
	CountryOfOrigin NVARCHAR(40) NOT NULL
)
GO 
Create Table Customers
(
	CustomerId INT PRIMARY KEY,
	CustomerName NVARCHAR(40) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(150) NOT NULL,
)
CREATE TABLE Orders
(
    [OrderId]      INT  NOT NULL PRIMARY KEY,
    [OrderDate]    DATE NOT NULL,
    [DeliveryDate] DATE NULL,
    CustomerId INT NOT NULL REFERENCES Customers(CustomerId) 
)
GO
CREATE TABLE [dbo].[OrderItems] (
    [OrderId]   INT NOT NULL REFERENCES Orders(OrderId),
    [MobileDeviceId] INT NOT NULL REFERENCES MobileDevices(MobileDeviceId),
    [Quantity]  INT NOT NULL
)