
CREATE TABLE [dbo].[CatCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[CreateAt] [datetime] NOT NULL DEFAULT GETDATE(),
	[EdithAt] [datetime] NOT NULL DEFAULT GETDATE(),
	[Active] [bit] NOT NULL DEFAULT 1
);
CREATE TABLE [dbo].[CatProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCategory] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[CreateAt] [datetime] NOT NULL DEFAULT GETDATE(),
	[EdithAt] [datetime] NOT NULL DEFAULT GETDATE(),
	[Active] [bit]DEFAULT(1)  NOT NULL
);
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[StockMax] [int] NOT NULL,
	[StockMin] [int] NOT NULL
);
CREATE TABLE [dbo].[InventoryMovements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Motion] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL DEFAULT GETDATE()
);
CREATE TABLE [dbo].[Sessions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Token] [nvarchar](500) NOT NULL,
	[ExpiresAt] [datetime](7) NOT NULL DEFAULT GETDATE(),
	[CreatedAt] [datetime](7) NOT NULL DEFAULT GETDATE(),
);
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[User] [int] IDENTITY(10000,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [varbinary](255) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
	[CreatedAt] [datetime] NOT NULL DEFAULT GETDATE(),
 ); 

USE [ProductInventoryDB]
GO
SET IDENTITY_INSERT [dbo].[CatCategory] ON 
GO
INSERT [dbo].[CatCategory] ([Id], [Name], [Description], [CreateAt], [EdithAt], [Active]) VALUES (1, N'Cocina', N'Productos para la cocina del hogar', CAST(N'2025-12-23T01:57:44.190' AS DateTime), CAST(N'2025-12-23T01:58:37.790' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[CatCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[CatProducts] ON 
GO
INSERT [dbo].[CatProducts] ([Id], [IdCategory], [Name], [Description], [CreateAt], [EdithAt], [Active]) VALUES (1, 1, N'Sarten', N'Sarten ceramico de 5 pulgadas', CAST(N'2025-12-23T01:59:44.397' AS DateTime), CAST(N'2025-12-23T01:59:44.397' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[CatProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventory] ON 
GO
INSERT [dbo].[Inventory] ([Id], [IdProduct], [Stock], [StockMax], [StockMin]) VALUES (1, 1, 6, 5, 3)
GO
SET IDENTITY_INSERT [dbo].[Inventory] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryMovements] ON 
GO
INSERT [dbo].[InventoryMovements] ([Id], [IdProduct], [Motion], [UserId], [CreatedAt]) VALUES (1, 1, -1, 10000, CAST(N'2025-12-23T02:02:46.523' AS DateTime))
GO
INSERT [dbo].[InventoryMovements] ([Id], [IdProduct], [Motion], [UserId], [CreatedAt]) VALUES (2, 1, 3, 10000, CAST(N'2025-12-23T05:08:24.190' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[InventoryMovements] OFF
GO
INSERT [dbo].[Sessions] ([Id], [UserId], [Token], [ExpiresAt], [CreatedAt]) VALUES (N'e2d38c7c-062b-47b8-9ff4-4bdce0dc50a5', N'e5072a56-7861-4c09-b980-8bbc05576948', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlNTA3MmE1Ni03ODYxLTRjMDktYjk4MC04YmJjMDU1NzY5NDgiLCJlbWFpbCI6InRlc3RAbWFpbC5jb20iLCJleHAiOjE3NjY1MDM0NDIsImlzcyI6IlByb2R1Y3RJbnZlbnRvcnkuQXBpIiwiYXVkIjoiUHJvZHVjdEludmVudG9yeS5DbGllbnQifQ.aXoJVhV1iDR2Xgg_3Pt0w5eSXmV121MxWXVEx334BC0', CAST(N'2025-12-23T09:28:02.1932155' AS DateTime2), CAST(N'2025-12-23T09:23:02.1932141' AS DateTime2))
GO
INSERT [dbo].[Sessions] ([Id], [UserId], [Token], [ExpiresAt], [CreatedAt]) VALUES (N'ee5e55aa-b837-4451-a29b-9527926c78d6', N'e5072a56-7861-4c09-b980-8bbc05576948', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlNTA3MmE1Ni03ODYxLTRjMDktYjk4MC04YmJjMDU1NzY5NDgiLCJlbWFpbCI6InRlc3RAbWFpbC5jb20iLCJleHAiOjE3NjY1MTg2MjEsImlzcyI6IlByb2R1Y3RJbnZlbnRvcnkuQXBpIiwiYXVkIjoiUHJvZHVjdEludmVudG9yeS5DbGllbnQifQ.YahXfjSK5o_xXk09X3zRjMo3ICukYu3hStLvV1nlnHQ', CAST(N'2025-12-23T13:37:01.6457492' AS DateTime2), CAST(N'2025-12-22T13:37:01.6457492' AS DateTime2))
GO
INSERT [dbo].[Sessions] ([Id], [UserId], [Token], [ExpiresAt], [CreatedAt]) VALUES (N'76f3579c-dffa-4464-a56b-f2e72f4ecd5b', N'e5072a56-7861-4c09-b980-8bbc05576948', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlNTA3MmE1Ni03ODYxLTRjMDktYjk4MC04YmJjMDU1NzY5NDgiLCJlbWFpbCI6InRlc3RAbWFpbC5jb20iLCJleHAiOjE3NjY1MTgyMTAsImlzcyI6IlByb2R1Y3RJbnZlbnRvcnkuQXBpIiwiYXVkIjoiUHJvZHVjdEludmVudG9yeS5DbGllbnQifQ.7OyVPvV2mLTvXkmE3rfXgXJvVXNpV_ujvhMsTfu8hww', CAST(N'2025-12-23T13:30:10.6599293' AS DateTime2), CAST(N'2025-12-22T13:30:10.6599293' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [User], [Email], [Password], [IsActive], [CreatedAt]) VALUES (N'e5072a56-7861-4c09-b980-8bbc05576948', 10000, N'test@mail.com', 0x41514141414149414159616741414141454633336A594A675855424B4778304D6A395033496975444F5A354C535A6A6C42364A427157633570514A587259314D796B5937494174513978536A424D4F4234513D3D, 1, CAST(N'2025-12-22T12:36:27.853' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO


