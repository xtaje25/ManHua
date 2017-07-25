USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Menu]    Script Date: 2017/07/25 17:38:44 ******/
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
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (6, N'公号目录', N'GZH/Catalog', 1, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (7, N'公号信息', N'GZH/Info', 1, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (8, N'员工账号', N'User/List', 2, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (9, N'漫画目录', N'MH/Catalog', 3, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (10, N'漫画定价', N'Sale/Price', 4, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (11, N'已支付订单', N'Order/Pay', 5, 1)
INSERT [dbo].[Tab_Menu] ([F_Id], [F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (12, N'已消费订单', N'Order/Cancel', 5, 1)
SET IDENTITY_INSERT [dbo].[Tab_Menu] OFF
ALTER TABLE [dbo].[Tab_Menu] ADD  CONSTRAINT [DF_Tab_Menu_F_ParentId]  DEFAULT ((0)) FOR [F_ParentId]
GO
