USE [MH]
GO
/****** Object:  Table [dbo].[Tab_User]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_User](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [nvarchar](50) NOT NULL,
	[F_Password] [nvarchar](50) NOT NULL,
	[F_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tab_User] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_User] ON 

INSERT [dbo].[Tab_User] ([F_Id], [F_Name], [F_Password], [F_CreateDate]) VALUES (1, N'Admin', N'123123', CAST(N'2017-07-23T17:00:40.430' AS DateTime))
INSERT [dbo].[Tab_User] ([F_Id], [F_Name], [F_Password], [F_CreateDate]) VALUES (2, N'aaa', N'123456', CAST(N'2017-07-25T14:18:27.537' AS DateTime))
INSERT [dbo].[Tab_User] ([F_Id], [F_Name], [F_Password], [F_CreateDate]) VALUES (3, N'公号1管理员1', N'123456', CAST(N'2017-07-30T16:37:01.607' AS DateTime))
INSERT [dbo].[Tab_User] ([F_Id], [F_Name], [F_Password], [F_CreateDate]) VALUES (4, N'公号2管理员1', N'123456', CAST(N'2017-07-30T16:37:10.057' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tab_User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tab_User]    Script Date: 2017/07/31 15:21:48 ******/
ALTER TABLE [dbo].[Tab_User] ADD  CONSTRAINT [IX_Tab_User] UNIQUE NONCLUSTERED 
(
	[F_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tab_User] ADD  CONSTRAINT [DF_Tab_User_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
