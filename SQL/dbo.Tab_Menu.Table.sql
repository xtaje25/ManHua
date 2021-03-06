USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Menu]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_Menu](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [nvarchar](50) NOT NULL,
	[F_URL] [nvarchar](500) NOT NULL,
	[F_ParentId] [int] NOT NULL,
	[F_Site] [int] NOT NULL,
 CONSTRAINT [PK_Tab_Menu] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_Menu] ON 

INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (1, N'公号管理', N'GZH', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (2, N'账号管理', N'User', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (3, N'漫画管理', N'MH', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (4, N'营销管理', N'Sale', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (5, N'订单管理', N'Order', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (6, N'公号目录', N'GZH/CatalogView', 1, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (7, N'公号信息', N'GZH/InfoView', 1, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (8, N'员工账号', N'User/ListView', 2, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (9, N'漫画目录', N'MH/CatalogView', 3, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (10, N'漫画定价', N'Sale/PriceView', 4, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (11, N'已支付订单', N'Order/PayView', 5, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (12, N'已消费订单', N'Order/CancelView', 5, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (13, N'添加公号', N'GZH/AddView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (14, N'', N'GZH/Add', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (15, N'', N'GZH/Delete', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (16, N'', N'GZH/EditView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (17, N'', N'GZH/Edit', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (18, N'', N'GZH/InfoEditView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (19, N'', N'GZH/InfoEdit', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (20, N'添加漫画目录', N'MH/AddView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (21, N'', N'MH/Add', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (22, N'编辑漫画目录', N'MH/EditView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (23, N'', N'MH/Edit', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (24, N'添加漫画定价', N'Sale/AddView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (25, N'添加漫画定价', N'Sale/Add', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (26, N'删除漫画定价', N'Sale/Delete', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (27, N'编辑漫画定价', N'Sale/EditView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (28, N'编辑漫画定价', N'Sale/Edit', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (29, N'添加用户', N'User/AddView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (30, N'添加用户', N'User/Add', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (31, N'编辑用户', N'User/EditView', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (32, N'编辑用户', N'User/Edit', 0, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (33, N'删除用户', N'User/Delete', 0, 1)
SET IDENTITY_INSERT [dbo].[Tab_Menu] OFF
ALTER TABLE [dbo].[Tab_Menu] ADD  CONSTRAINT [DF_Tab_Menu_F_ParentId]  DEFAULT ((0)) FOR [F_ParentId]
GO
