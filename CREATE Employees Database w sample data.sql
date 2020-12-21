SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Employees];
GO

CREATE TABLE [dbo].[Employees] (
    [EmployeeId]     INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]      VARCHAR (255) NOT NULL,
    [LastName]       VARCHAR (255) NOT NULL,
    [EmployeeTypeId] INT           NOT NULL
);
GO

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (1, N'Bea', N'Langford', 3)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (2, N'Mary', N'Jane', 2)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (3, N'Matt', N'Larkin', 1)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (4, N'John', N'Smith', 2)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (5, N'Ann', N'Landers', 1)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (6, N'June', N'Cleaver', 2)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (8, N'Bob', N'Jones', 1)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (9, N'Harve', N'Bennett', 2)
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmployeeTypeId]) VALUES (13, N'Gene', N'Kuntz', 2)
SET IDENTITY_INSERT [dbo].[Employees] OFF

/****** Object: Table [dbo].[EmployeeTypes] Script Date: 12/21/2020 10:23:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[EmployeeTypes];
GO

CREATE TABLE [dbo].[EmployeeTypes] (
    [EmployeeTypeId]   INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeTypeName] VARCHAR (255) NOT NULL
);
GO

SET IDENTITY_INSERT [dbo].[EmployeeTypes] ON
INSERT INTO [dbo].[EmployeeTypes] ([EmployeeTypeId], [EmployeeTypeName]) VALUES (1, N'Lowly Peon')
INSERT INTO [dbo].[EmployeeTypes] ([EmployeeTypeId], [EmployeeTypeName]) VALUES (2, N'Grand Poobah')
INSERT INTO [dbo].[EmployeeTypes] ([EmployeeTypeId], [EmployeeTypeName]) VALUES (3, N'Supreme Leader')
SET IDENTITY_INSERT [dbo].[EmployeeTypes] OFF