USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Authorization]    Script Date: 2017/07/24 18:23:49 ******/
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
SET IDENTITY_INSERT [dbo].[Tab_Authorization] OFF
ALTER TABLE [dbo].[Tab_Authorization] ADD  CONSTRAINT [DF_Tab_Authorization_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
