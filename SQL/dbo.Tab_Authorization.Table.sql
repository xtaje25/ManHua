USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Authorization]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_Authorization](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [nvarchar](50) NOT NULL,
	[F_AuthType] [nvarchar](50) NOT NULL,
	[F_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tab_Authorization] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_Authorization] ON 

INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (1, N'公号目录', N'menu', CAST(N'2017-07-24T17:56:23.770' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (2, N'公号信息', N'menu', CAST(N'2017-07-24T17:56:23.770' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (3, N'员工账号', N'menu', CAST(N'2017-07-24T17:56:23.773' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (4, N'漫画目录', N'menu', CAST(N'2017-07-24T17:56:23.773' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (5, N'漫画定价', N'menu', CAST(N'2017-07-24T17:56:23.773' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (6, N'已支付订单', N'menu', CAST(N'2017-07-24T17:56:23.773' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (7, N'已消费订单', N'menu', CAST(N'2017-07-24T17:56:23.773' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (8, N'添加公号', N'url', CAST(N'2017-07-26T14:34:40.820' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (9, N'添加公号', N'url', CAST(N'2017-07-26T14:40:14.217' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (10, N'删除公号', N'url', CAST(N'2017-07-26T17:25:14.467' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (11, N'公号编辑', N'url', CAST(N'2017-07-26T17:26:21.327' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (12, N'', N'url', CAST(N'2017-07-26T17:27:06.633' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (13, N'公号信息编辑', N'url', CAST(N'2017-07-27T10:23:35.663' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (14, N'', N'url', CAST(N'2017-07-27T10:24:43.943' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (15, N'添加漫画目录', N'url', CAST(N'2017-07-27T16:49:04.440' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (16, N'', N'url', CAST(N'2017-07-27T16:50:10.033' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (17, N'编辑漫画目录', N'url', CAST(N'2017-07-27T18:32:51.410' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (18, N'', N'url', CAST(N'2017-07-27T18:33:53.790' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (19, N'添加漫画定价', N'url', CAST(N'2017-07-28T13:48:29.777' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (20, N'添加漫画定价', N'url', CAST(N'2017-07-28T13:49:45.840' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (21, N'删除漫画定价', N'url', CAST(N'2017-07-28T13:50:29.183' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (22, N'编辑漫画定价', N'url', CAST(N'2017-07-29T22:47:38.430' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (23, N'编辑漫画定价', N'url', CAST(N'2017-07-29T22:48:55.147' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (24, N'添加用户', N'url', CAST(N'2017-07-30T14:45:34.870' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (25, N'添加用户', N'url', CAST(N'2017-07-30T14:49:09.380' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (26, N'编辑用户', N'url', CAST(N'2017-07-30T14:49:53.433' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (27, N'编辑用户', N'url', CAST(N'2017-07-30T14:50:32.903' AS DateTime))
INSERT [dbo].[Tab_Authorization] ([F_Id], [F_Name], [F_AuthType], [F_CreateDate]) VALUES (28, N'删除用户', N'url', CAST(N'2017-07-30T14:51:14.673' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tab_Authorization] OFF
ALTER TABLE [dbo].[Tab_Authorization] ADD  CONSTRAINT [DF_Tab_Authorization_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
