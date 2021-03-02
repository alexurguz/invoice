CREATE DATABASE InvoiceDB;

USE [InvoiceDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Names] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[DateBirth] [date] NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Status] [varchar](15) NOT NULL,
    [Deleted] [bit] NOT NULL DEFAULT 0,
	[CreateDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Price] [decimal](18,10) NOT NULL DEFAULT 0,
	[Status] [varchar](15) NOT NULL,
    [Deleted] [bit] NOT NULL DEFAULT 0,
	[CreateDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesInvoice](
    [IdSalesInvoice] [int] IDENTITY(1,1) NOT NULL,
    [IdCustomer] [int] NOT NULL,
	[DateSales] [date] NOT NULL,
	[Address] [varchar](200) NULL,
	[Country] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[Discount] [decimal](18,10) NOT NULL DEFAULT 0,
	[Total] [decimal](18,10) NOT NULL DEFAULT 0,
	[TotalWithoutDiscount] [decimal](18,10) NOT NULL DEFAULT 0,
	[Status] [varchar](15) NOT NULL,
    [Deleted] [bit] NOT NULL DEFAULT 0,
	[CreateDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_SalesInvoice] PRIMARY KEY CLUSTERED 
(
	[IdSalesInvoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesInvoiceProducts](
	[IdSalesInvoiceProduct] [int] IDENTITY(1,1) NOT NULL,
	[IdSalesInvoice] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
    [Quantity] [int] NOT NULL DEFAULT 0,
	[UnitValue] [decimal](18,10) NOT NULL DEFAULT 0,
	[TotalValue] [decimal](18,10) NOT NULL DEFAULT 0,
    [Deleted] [bit] NOT NULL DEFAULT 0,
	[CreateDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_SalesInvoiceProducts] PRIMARY KEY CLUSTERED 
(
	[IdSalesInvoiceProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SalesInvoice]  WITH NOCHECK ADD  CONSTRAINT [FK_User_CustomerId] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[SalesInvoice] CHECK CONSTRAINT [FK_User_CustomerId]

GO
ALTER TABLE [dbo].[SalesInvoiceProducts]  WITH NOCHECK ADD  CONSTRAINT [FK_Sales_InvoiceId] FOREIGN KEY([IdSalesInvoice])
REFERENCES [dbo].[SalesInvoice] ([IdSalesInvoice])
GO
ALTER TABLE [dbo].[SalesInvoiceProducts] CHECK CONSTRAINT [FK_Sales_InvoiceId]

GO
ALTER TABLE [dbo].[SalesInvoiceProducts]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductId] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([IdProduct])
GO
ALTER TABLE [dbo].[SalesInvoiceProducts] CHECK CONSTRAINT [FK_ProductId]

INSERT [dbo].[User] 
([Names], [LastName], [Email], [DateBirth], [PhoneNumber], [Status], [Deleted] , [CreateDate], [UpdateDate]) 
VALUES 
('Johnatan Alexis', 'Urbano Guzmán', 'johnurbaguz@gmail.com', '1988-01-18', '(+57)3175910407', 'Active', 0, '2020-09-28', '2020-09-28');

INSERT [dbo].[Product] 
([Name], [Description], [Price], [Status], [Deleted], [CreateDate], [UpdateDate]) 
VALUES 
('Producto 1', 'Porducto de muestra', 10000, 'Active', 0, '2020-09-28', '2020-09-28');

INSERT [dbo].[SalesInvoice] 
([IdCustomer], [DateSales], [Address], [Country], [City], [Discount], [Total], [TotalWithoutDiscount], [Status], [Deleted], [CreateDate], [UpdateDate]) 
VALUES 
(1, '2020-09-28', 'AV 4A OESTE # 13-52', 'Colombia', 'Cali', 10000, 120000, 11000, 'Active', 0, '2020-09-28', '2020-09-28');

INSERT [dbo].[SalesInvoiceProducts] 
([IdSalesInvoice], [IdProduct], [Quantity], [UnitValue], [TotalValue], [Deleted], [CreateDate], [UpdateDate])
VALUES 
(1, 1, 2, 60000, 120000, 0, '2020-09-28', '2020-09-28');
