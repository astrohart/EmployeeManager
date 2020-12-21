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